using System;
using System.Globalization;

namespace LE_NEVEZ_Logan_Tp2
{
    public class SpaceInvaders
    {
        // Liste des Joueurs
        private List<Player> Players { get; set; }

        public SpaceInvaders()
        {
            Init();
        }

        public static void Main()
        {
            // Instanciation d'un nouveau SpaceInvaders
            SpaceInvaders game = new SpaceInvaders();

            // Instanciation d'une nouvelle Armory
            Armory armory = new Armory();

            // Attribution des vaisseaux aux joueurs
            Spaceship p1 = game.Players[0].Spaceship;
            Spaceship p2 = game.Players[1].Spaceship;
            Spaceship p3 = game.Players[2].Spaceship;

            // Ajout des armes pour les joueurs
            p1.AddWeapon(armory.GetWeapon("Hard Riffle"));
            p1.AddWeapon(armory.GetWeapon("Sword"));
            p2.AddWeapon(armory.GetWeapon("Grenade Launcher"));
            p3.AddWeapon(armory.GetWeapon("Sword"));
            p3.AddWeapon(armory.GetWeapon("Grenade Launcher"));

            // Finalement le joueur 3 n'aura pas d'armes dans son vaisseau... :)
            p3.ClearWeapons();

            //Et le joueur 1 n'a pas besoin d'épée dans l'espace WTF ?
            p1.RemoveWeapon(armory.GetWeapon("Sword"));

            Console.WriteLine("-- Armory --\n");
            armory.ViewArmory();

            foreach (Player p in game.Players)
            {
                // Affichage du nom du vaisseau
                Console.WriteLine($"\n-- Spaceship {p.Spaceship.Name.ToString()} --\n");

                // Affichage du Membre à bord du vaisseau
                Console.WriteLine($"Member : {p.ToString()}");

                // Affichage des armes présentes dans le vaisseau
                p.Spaceship.ViewWeapons();

                // Affichage des caractéristiques du vaisseau
                p.Spaceship.ViewShip();
            }
        }

        // Création d'une liste de Joueur avec 3 nouveaux ajout de joueurs
        private List<Player> Init()
        {
            Players = new List<Player>();

            Players.Add(new Player("logan", "le-nevez", "Nagol67", new Spaceship("Cooperaten", 20, 100, 15, 80)));
            Players.Add(new Player("joé", "feucht", "xxDarkJoé69xx", new Spaceship("Millennium Falcon", 30, 200, 0, 200)));
            Players.Add(new Player("younes", "bokhari", "Fatal Bazooka", new Spaceship("Air Bus", 90, 300, 60, 299)));

            return Players;
        }
    }
}