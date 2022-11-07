using System;
using System.Globalization;

namespace LE_NEVEZ_Logan_Tp2
{
    public class Player
    {
        // Propriétés
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Alias { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }

        public Spaceship Spaceship { get; private set; }

        // Constructeur
        public Player(string firstName, string lastName, string alias, Spaceship spaceship)
        {
            FirstName = Format(firstName);
            LastName = Format(lastName);
            Alias = alias;
            Spaceship = spaceship;
        }

        // Méthode qui formatte la première lettre d'un string en majuscule
        private static string Format(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        // Réecriture de la méthode ToString pour qu'elle renvoie Pseudo suivi de Prénom Nom
        public override string ToString()
        {
            return $"{Alias} ({Name})";
        }

        // Réecriture de la méthode Equals pour comparer deux joueurs (leur pseudo)
        public override bool Equals(object? obj)
        {
            if (obj is Player same) return Alias.Equals(same.Alias);
            return false;
        }

        // Ajout d'un vaisseau par défaut
        public void DefaultSpaceship(Spaceship spaceship)
        {
            Spaceship = spaceship;
        }
    }
}