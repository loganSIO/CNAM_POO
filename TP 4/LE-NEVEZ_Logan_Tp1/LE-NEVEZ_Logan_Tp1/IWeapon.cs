using System;

namespace LE_NEVEZ_Logan_Tp1
{
    public interface IWeapon
    {
        string Name { get; set; }
        EWeaponType WeaponType { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        double TimeBeforeReload { get; set; }
        int Shoot();
    }
}