using System;

namespace LE_NEVEZ_Logan_Tp1
{
    public class Rocinante : Spaceship
    {
        public Rocinante()
        {
            Name = "Rocinante";
            Structure = 3;
            Shield = 5;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        }

    }
}
