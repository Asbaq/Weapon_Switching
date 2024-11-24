using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Weapon[] weapons; // Array to hold all weapons
    private Weapon activeWeapon;
    public AudioSource audioSource; // Assign an AudioSource in the inspector
    public AudioClip switchWeaponClip; // Assign the audio clip in the inspector
    public Button[] Buttons;

    public void SwitchWeapon(Weapon newWeapon)
    {

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }

        if (activeWeapon != null)
        {
            activeWeapon.Deactivate();
        }

        // Play the audio clip and wait before activating the new weapon
        StartCoroutine(SwitchWeaponWithAudio(newWeapon));
    }

    private IEnumerator SwitchWeaponWithAudio(Weapon newWeapon)
    {
        if (switchWeaponClip != null && audioSource != null)
        {
            // Play the audio clip
            audioSource.clip = switchWeaponClip;
            audioSource.Play();

            // Wait for the clip to finish playing
            yield return new WaitForSeconds(switchWeaponClip.length);
        }

        // Activate the new weapon after the delay
        activeWeapon = newWeapon;
        activeWeapon.Activate();
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = true;
        }
    }
}
