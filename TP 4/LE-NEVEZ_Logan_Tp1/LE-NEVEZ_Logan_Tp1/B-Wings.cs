using System;

namespace LE_NEVEZ_Logan_Tp1
{
    public class B_Wings : Spaceship
    {
        public B_Wings()
        {
            Name = "B-Wings";
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Direct, 1.5));
        }

        public override void AddWeapon(Weapon w)
        {
            if (w.WeaponType == EWeaponType.Explosive)
                w.ReloadTime = 1;

            base.AddWeapon(w);
        }

    }
}