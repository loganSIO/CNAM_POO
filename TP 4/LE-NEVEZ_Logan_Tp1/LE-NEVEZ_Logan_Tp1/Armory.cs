namespace LE_NEVEZ_Logan_Tp1
{
    public class Armory
    {
        #region Patern singleton
        private static readonly Lazy<Armory> lazy = new Lazy<Armory>(() => new Armory());

        public List<Weapon> Weapons { get; set; }

        public static Armory Instance
        {
            get { return lazy.Value; }
        }

        private Armory()
        {
            Init();
        }

        #endregion Patern singleton

        // Initiation de toutes les armes de l'armurerie
        private void Init()
        {
            Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
            Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
            Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1)); 
            Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
            Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        // Affichage de l'armurerie
        public override string ToString()
        {
            string text = "";
            foreach (var w in Weapons)
            {
                text += w.ToString();
                text += "|\n";
            }


            return text;
        }
        public List<Weapon> FiveBiggestAverageDamageWeapons()
        {
            return Weapons.OrderBy(x => x.AverageDamage()).Take(5).ToList();
        }
        public List<Weapon> FiveBiggestMinDamageWeapons()
        {
            // modif pour retourner le plus grand des petits
            return Weapons.OrderBy(x => x.MinDamage).Take(5).ToList();
        }
    }
}