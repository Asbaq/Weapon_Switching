# Weapon_Switching
 Weapon_Switching

Script


 Abstract Class - Weapon

 using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public string WeaponName { get; protected set; }
    public abstract void Activate();
    public abstract void Deactivate();
}


Derived Class - FireWeapon

using UnityEngine;

public class FireWeapon : Weapon
{

    private void Awake()
    {
        WeaponName = "Fire";
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        Debug.Log($"{WeaponName} weapon activated.");
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
        Debug.Log($"{WeaponName} weapon deactivated.");
    }
}


Derived Class - IceWeapon

using UnityEngine;

public class IceWeapon : Weapon
{

    private void Awake()
    {
        WeaponName = "Ice";
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        Debug.Log($"{WeaponName} weapon activated.");
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
        Debug.Log($"{WeaponName} weapon deactivated.");
    }
}


Derived Class - ElectricityWeapon

using UnityEngine;

public class ElectricityWeapon : Weapon
{

    private void Awake()
    {
        WeaponName = "Electricity";
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        Debug.Log($"{WeaponName} weapon activated.");
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
        Debug.Log($"{WeaponName} weapon deactivated.");
    }
}


WeaponManager


using UnityEngine;
public class WeaponManager : MonoBehaviour
{

    public Weapon[] weapons; // Array to hold all weapons
    private Weapon activeWeapon;
    public AudioSource audioSource; // Assign an AudioSource in the inspector
    public AudioClip switchWeaponClip; // Assign the audio clip in the inspector

    public void SwitchWeapon(Weapon newWeapon)
    {
        if (activeWeapon != null)
        {
            activeWeapon.Deactivate();
        }

        // Play the audio clip and wait before activating the new weapon
        StartCoroutine(SwitchWeaponWithAudio(newWeapon));
    }

    private System.Collections.IEnumerator SwitchWeaponWithAudio(Weapon newWeapon)
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
    }
}


WeaponButton

using UnityEngine;

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


VFX Graph Setting for FireWeapon

Gradient Setup

UV Node → Split Node (G Channel) → Lerp Node (T Input).
Color A (Orange) → Lerp Node A Input.
Color B (Red) → Lerp Node B Input.
Lerp Node Output → Multiply Node A.


Noise for Flickering

Time Node → Tiling and Offset Node (Offset Input).
Tiling and Offset Node Output → Simple Noise Node (UV Input).
Simple Noise Node Output -> Multiply Node B.

Multiply Node -> Base Color.


Thought process behind the visual effects for each weapon.

Element or Energy Type:

Fire: Flames, embers, and heat distortions.
Ice: Frost particles, cool glow, and breaking shards.
Lightning: Sparks, arcs, and a glowing charge.


VFX Graph Setting for IceWeapon

Gradient Setup

UV Node → Split Node (G Channel) → Lerp Node (T Input).
Color A (Blue) → Lerp Node A Input.
Color B (DarkBlue) → Lerp Node B Input.
Lerp Node Output → Multiply Node A.


Noise for Flickering

Time Node → Tiling and Offset Node (Offset Input).
Tiling and Offset Node Output → Simple Noise Node (UV Input).
Simple Noise Node Output -> Multiply Node B.

Multiply Node -> Base Color.


VFX Graph Setting for ElectricityWeapon

Gradient Setup

UV Node → Split Node (G Channel) → Lerp Node (T Input).
Color A (DarkBlue) → Lerp Node A Input.
Color B (Voilet) → Lerp Node B Input.
Lerp Node Output → Multiply Node A.


Noise for Flickering

Time Node → Tiling and Offset Node (Offset Input).
Tiling and Offset Node Output → Simple Noise Node (UV Input).
Simple Noise Node Output -> Multiply Node B.

Multiply Node -> Base Color.


Optimized for Mobile

Noise: Use pre-baked noise textures instead of procedural nodes.

Gradients: Use pre-baked gradient textures instead of procedural generation.

Glow/Emission: Simplify glow intensity with Multiply instead of Power; avoid HDR and heavy bloom.

Transparency: Minimize overdraw; use Alpha Clip for fully transparent areas.

Textures: Compress textures (ETC2/ASTC) and use low resolution (e.g., 256x256).

Node Precision: Set nodes to Half Precision where possible.

Profile: Test with Unity Profiler and real devices for performance validation.



