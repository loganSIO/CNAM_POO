using System;

namespace LE_NEVEZ_Logan_Tp1
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII()
        {
            Name = "ViperMKII";
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine("Player shoot enemy spaceship");
            Weapons.ForEach(w => w.TimeBeforeReload--);

            var rnd = new Random();
            var start = rnd.Next(0, Weapons.Count);
            bool hasShoot = false;

            for (int i = 0; i < Weapons.Count && !hasShoot; i++)
            {
                if (Weapons[start].TimeBeforeReload == 0)
                {
                    int damage = (int)Weapons[start].Shoot();
                    target.TakeDamage(damage);

                    if (target.IsDestroyed)
                        Console.WriteLine($"Damages: {damage}\nHas destroyed enemy spaceship : Yes\n");
                    else
                        Console.WriteLine($"Damages: {damage}\nHas destroyed enemy spaceship : No \n");
                }

                start++;
                if (start == Weapons.Count)
                    start = 0;
            }
        }

    }
}
