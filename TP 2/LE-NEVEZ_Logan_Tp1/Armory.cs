namespace LE_NEVEZ_Logan_Tp2

{
    public class Armory
    {
        public List<Weapon> Weapons { get; set; }

        public Armory()
        {
            Weapons = new List<Weapon>();
            Init();
        }

        // Récupère une arme dans le construteur de Weapon avec son nom
        public Weapon GetWeapon(string name)
        {
            foreach (Weapon weapon in Weapons)
            {
                if (weapon.Name == name)
                {
                    return weapon;
                }
            }
            return null;
        }

        // Affiche les armes présentes dans l'Armurerie
        public void ViewArmory()
        {
            foreach (Weapon w in Weapons)
            {
                Console.WriteLine($"{w.Name}, {w.MinDamage}, {w.MaxDamage}, {w.WeaponType}");
            };
        }

        private void Init()
        {
            Weapons.Add(new Weapon("Sword", 12, 50, Weapon.EWeaponType.Direct));
            Weapons.Add(new Weapon("Hard Riffle", 50, 90, Weapon.EWeaponType.Guided));
            Weapons.Add(new Weapon("Grenade Launcher", 20, 150, Weapon.EWeaponType.Explosive));
        }
    }
}