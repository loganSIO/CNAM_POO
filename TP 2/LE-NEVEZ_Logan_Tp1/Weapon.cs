namespace LE_NEVEZ_Logan_Tp2
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public EWeaponType WeaponType { get; set; }

        public Weapon(string name, int mindamage, int maxdamage, EWeaponType weapontype)
        {
            Name = name;
            MinDamage = mindamage;
            MaxDamage = maxdamage;
            WeaponType = weapontype;
        }

        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided,
        }
    }
}