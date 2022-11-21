using System;

namespace LE_NEVEZ_Logan_Tp1
{
    public class Dart : Spaceship
    {
        public Dart()
        {
            Name = "Dart";
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 1));
        }

        // Ajout d'arme
        public override void AddWeapon(Weapon w)
        {
            if (w.WeaponType == EWeaponType.Direct)
                w.ReloadTime = 1;
            base.AddWeapon(w);
        }

    }
}
