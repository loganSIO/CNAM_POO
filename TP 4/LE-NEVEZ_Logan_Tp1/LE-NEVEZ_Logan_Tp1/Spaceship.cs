namespace LE_NEVEZ_Logan_Tp1
{
    public abstract class Spaceship : ISpaceship
    {
        public List<Weapon> Weapons { get; set; }
        public int _currentstructure;

        public string Name { get; set; }
        public int Structure { get; set; }
        public int Shield { get; set; }
        public int CurrentStructure
        {
            get
            {
                return _currentstructure;
            }
            set
            {
                _currentstructure = value;
                if (_currentstructure == 0)
                {
                    IsDestroyed = true;
                }
            }

        }
        public int CurrentShield { get; set; }
        public bool IsDestroyed { get; set; }

        public Spaceship()
        {
            Weapons = new List<Weapon>();
            Name = "Default";
            Structure = 100;
            Shield = 100;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        // Ajout d'arme dans un vaisseau
        public virtual void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count < 3)
            {
                if (!Weapons.Contains(weapon)) Weapons.Add(weapon);
            }
            else
            {
                Console.WriteLine("Can only handle 3 weapons on the ship");
            }
        }

        // Supression d'arme dans un vaisseau
        public void RemoveWeapon(Weapon oWeapon)
        {
            Weapons.Remove(oWeapon);
        }

        // Supprime toutes les armes dans un vaisseau
        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        // Affiche toutes les armes présentes dans un vaisseau
        public void ViewWeapons()
        {
            Console.WriteLine($"Weapons : {string.Join(", ", Weapons.Select(w => w.Name.ToString()))}");
        }

        // Affiche les dégâts moyens qu'un vaisseau peut causer avec ses armes
        public double AverageDamages()
        {
            return Weapons.Select(w => (w.MaxDamage - w.MinDamage) / 2d).Sum() / Weapons.Count;
        }

        // Répartition des pts de dégâts en fonction du bouclier puis de la structure
        public void TakeDamage(int damage)
        {
            if (CurrentShield - damage >= 0)
            {
                CurrentShield -= damage;
            }
            else if (CurrentShield > 0)
            {
                damage -= CurrentShield;
                CurrentShield = 0;
                CurrentStructure -= damage;
            }
            else
            {
                CurrentStructure = CurrentStructure >= damage ? CurrentStructure - damage : 0;
            }
        }

        // Permet de tirer sur un vaisseau ajouté en paramètre
        public virtual void ShootTarget(Spaceship target)
        {
            Random random = new Random();

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());
                int damages = (int)Weapons[randomWeapon].Shoot();
                target.TakeDamage(damages);
            }
        }

        // Affichage des caractéristiques du vaisseau
        public void ViewShip()
        {
            Console.WriteLine("Current Spaceship :");
            Console.WriteLine($"\tName : {Name}");
            Console.WriteLine($"\tWeapons : {Weapons.Count}");
            Console.WriteLine($"\tStructure : {CurrentStructure}/{Structure}");
            Console.WriteLine($"\tShield : {CurrentShield}/{Shield}");
            Console.WriteLine($"\tAverage Damages : {AverageDamages()}");
            Console.WriteLine($"\tIs Destroyed : {IsDestroyed}");
        }
    }
}