using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string WeaponName { get; protected set; }
    public abstract void Activate();
    public abstract void Deactivate();
}
