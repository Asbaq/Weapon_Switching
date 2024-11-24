using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public Weapon weapon; // Assign the corresponding weapon in the Inspector
    private WeaponManager weaponManager;

    private void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    public void OnClick()
    {
        weaponManager.SwitchWeapon(weapon);
    }
}
