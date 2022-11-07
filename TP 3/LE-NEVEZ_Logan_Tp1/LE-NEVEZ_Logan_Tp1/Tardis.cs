using System;

namespace LE_NEVEZ_Logan_Tp1
{
    internal class Tardis : Spaceship, IAbility
    {
        public Tardis()
        {
            Name = "Tardis";
            Structure = 1;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine("Can't shoot, there is no Weapons");
        }

        // Abilité spéciale : prend un vaisseau au hasard et le change de place dans la liste
        public void UseAbility(List<Spaceship> spaceShips)
        {
            var rnd = new Random();
            var i = rnd.Next(0, spaceShips.Count);
            var j = rnd.Next(0, spaceShips.Count);
            var ship = spaceShips[i];
            spaceShips[i] = spaceShips[j];
            spaceShips[j] = ship;
            Console.WriteLine("Tardis changed place of one spaceship\n");
        }

    }
}
