using System;

namespace LE_NEVEZ_Logan_Tp1
{
    internal class F_18 : Spaceship, IAbility
    {
        public F_18()
        {
            Name = "Tardis";
            Structure = 15;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine("Can't shoot, there is no Weapons");
        }

        // Aptitude du F-18 (explose au contact d'autres vaisseau et fait 10 pts de dégâts)
        public void UseAbility(List<Spaceship> spaceShips)
        {
            bool hasBlewnUp = false;
            for (int i = 0; i < spaceShips.Count && !hasBlewnUp; i++)
            {
                if (spaceShips[i] == this)
                {
                    if (i == 0)
                    {
                        if (spaceShips[i + 1].GetType() == typeof(ViperMKII))
                        {
                            spaceShips[i].TakeDamage(10);
                            spaceShips[i + 1].TakeDamage(10);
                            spaceShips[i].Structure = 0;
                            spaceShips[i].Shield = 0;
                            hasBlewnUp = true;
                            Console.WriteLine("F-18 make an explosion\n");
                        }

                    }
                    else if (i == spaceShips.Count - 1)
                    {
                        if (spaceShips[i - 1].GetType() == typeof(ViperMKII))
                        {
                            spaceShips[i - 1].TakeDamage(10);
                            spaceShips[i].Structure = 0;
                            spaceShips[i].Shield = 0;
                            hasBlewnUp = true;
                            Console.WriteLine("F-18 make an explosion");
                        }
                    }
                    else
                    {
                        if (spaceShips[i - 1].GetType() == typeof(ViperMKII) || spaceShips[i + 1].GetType() == typeof(ViperMKII))
                        {
                            spaceShips[i - 1].TakeDamage(10);
                            spaceShips[i + 1].TakeDamage(10);
                            spaceShips[i].Structure = 0;
                            spaceShips[i].Shield = 0;
                            hasBlewnUp = true;
                            Console.WriteLine("F-18 make an explosion");
                        }
                    }
                }

            }

        }
    }
}