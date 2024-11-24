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
