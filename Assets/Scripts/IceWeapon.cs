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
