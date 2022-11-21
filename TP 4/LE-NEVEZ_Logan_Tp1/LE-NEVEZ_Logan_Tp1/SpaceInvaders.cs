using System;
using System.Globalization;

namespace LE_NEVEZ_Logan_Tp1
{
    public class SpaceInvaders
    {
        private static Player Player { get; set; }
        // Ajout d'une liste d'ennemis
        private static List<Spaceship> Enemy { get; set; }
        private static List<Spaceship> Ships { get; set; }
        private Armory Armory { get; }

        public SpaceInvaders()
        {
            Player = new Player("Younes", "BOKHARI", "xxYounesxx");
            Armory = Armory.Instance;
            Enemy = Init();
            Ships = new();
            Ships.Add(Player.Ship);
            Ships.AddRange(Enemy);
        }

        static void Main()
        {

            SpaceInvaders game = new();

            Console.WriteLine("-- Player --");
            Console.WriteLine(Player.ToString());
            Player.Ship.ViewShip();

            Console.WriteLine("-- Armory --");
            Console.WriteLine(game.Armory.ToString());

            Console.WriteLine("-- Game start --");

            while (!Player.Ship.IsDestroyed && Enemy.Where(e => !e.IsDestroyed).ToList().Count != 0)
            {
                game.PlayRound();
            }

            if (game.PlayerHasWon())
                Console.WriteLine("Player has won");
            else
                Console.WriteLine("Player lost");

            var biggestDamageWeapons = Armory.Instance.FiveBiggestAverageDamageWeapons();
            var biggestMinDamageWeapon = Armory.Instance.FiveBiggestMinDamageWeapons();

            Console.WriteLine("Les armes avec les plus gros dommages moyens : ");
            foreach (var item in biggestDamageWeapons)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Les armes avec les dommages minimums les plus hauts");
            foreach (var item in biggestMinDamageWeapon)
            {
                Console.WriteLine(item.ToString());
            }

        }

        static void Main(string[] args)
        {
            string path = args[0];
            var weaponImport = new ArmeImporteur();
            weaponImport.frequencyWord(path);

            weaponImport.newWeapon();
            var biggestDamageWeapons = Armory.Instance.FiveBiggestAverageDamageWeapons();
            var biggestMinDamageWeapon = Armory.Instance.FiveBiggestMinDamageWeapons();

            Console.WriteLine("5 five AVG weapons damage: ");
            foreach (var item in biggestDamageWeapons)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("5 five min weapons damage: ");
            foreach (var item in biggestMinDamageWeapon)
            {
                Console.WriteLine(item.ToString());
            }
        }

        // Liste de vaisseaux ennemis
        private List<Spaceship> Init()
        {
            List<Spaceship> ennemy = new();
            ennemy.Add(new Dart());
            ennemy.Add(new Rocinante());
            ennemy.Add(new B_Wings());
            ennemy.Add(new F_18());
            ennemy.Add(new Tardis());
            return ennemy;
        }


        public void PlayRound()
        {
            int count = 0;
            bool alreadyAttack = false;
            var rnd = new Random();

            GainShield();

            var listWithoutModification = new List<Spaceship>();
            listWithoutModification.AddRange(Ships);
            //si les vaisseaux ont des aptitudes
            foreach (var e in listWithoutModification)
            {
                if (e is IAbility newShip)
                {
                    newShip.UseAbility(Ships);
                }
            }

            // Tour de jeu des ennemis dans l'ordre de leur liste
            foreach (var e in Enemy)
            {
                // Tire sur un vaisseaux aléatoire en vie
                var alive = Enemy.Where(e => !e.IsDestroyed).ToList();
                if (rnd.Next(0, alive.Count) <= count && !alreadyAttack && !Player.Ship.IsDestroyed)
                {
                    // Joueur tire sur un vaisseaux random non mort
                    Player.Ship.ShootTarget(alive[rnd.Next(0, alive.Count)]);
                    alreadyAttack = true;
                }
                // Ennemis attaque le joueur
                e.ShootTarget(Player.Ship);
                count++;
            }

        }

        private void GainShield()
        {
            // Regagne 2 pts de boucliers (max) par vaisseaux au début du tour
            var damaged = Ships.Where(e => e.CurrentShield != e.Shield && !e.IsDestroyed).ToList();

            foreach (var e in damaged)
            {
                if (e.CurrentShield + 2 > e.Shield)
                    e.CurrentShield= e.Shield;
                else
                    e.CurrentShield += 2;
            }

        }

        public bool PlayerHasWon()
        {
            return Player.Ship.IsDestroyed ? false : true;
        }
    }
}