namespace LE_NEVEZ_Logan_Tp2
{
    public class Spaceship
    {
        public List<Weapon> Weapons { get; set; }
        public int _currentstructure;

        public string Name { get; set; }
        public int MaxStructure { get; private set; }
        public int MaxShield { get; private set; }
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
        public bool IsDestroyed;

        public Spaceship(string name, int maxStructure, int maxShield, int currentStructure, int currentShield)
        {
            Weapons = new List<Weapon>();
            Name = name;
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentStructure = currentStructure;
            CurrentShield = currentShield;
        }

        // Ajout d'arme dans un vaisseau
        public void AddWeapon(Weapon weapon)
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

        // Affichage des caractéristiques du vaisseau
        public void ViewShip()
        {
            Console.WriteLine("Current Spaceship :");
            Console.WriteLine($"\tWeapons : {Weapons.Count}");
            Console.WriteLine($"\tStructure : {CurrentStructure}/{MaxStructure}");
            Console.WriteLine($"\tShield : {CurrentShield}/{MaxShield}");
            Console.WriteLine($"\tAverage Damages : {AverageDamages()}");
            Console.WriteLine($"\tIs Destroyed : {IsDestroyed}");
        }
    }
}