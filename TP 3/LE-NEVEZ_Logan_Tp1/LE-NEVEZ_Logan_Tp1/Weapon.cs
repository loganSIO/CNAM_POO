namespace LE_NEVEZ_Logan_Tp1
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public int MinDamage { get; }
        public int MaxDamage { get; }
        public EWeaponType WeaponType { get; }
        public double ReloadTime { get; set; }
        public double TimeBeforeReload{ get; set; }
        public Weapon(string name, int mindamage, int maxdamage, EWeaponType weapontype, double reloadTime)
        {
            Name = name;
            MinDamage = mindamage;
            MaxDamage = maxdamage;
            WeaponType = weapontype;
            ReloadTime = reloadTime;
            TimeBeforeReload = WeaponType == EWeaponType.Explosive ? reloadTime * 2 : reloadTime;
        }

        // Methode Shoot vérifiant si elle peut attaquer, si oui, avec les différents retours disponibles.
        public int Shoot()
        {

            if (TimeBeforeReload == 0)
            {
                var rnd = new Random();
                var damage = rnd.Next(MinDamage, MaxDamage);
                switch (WeaponType)
                {
                    case EWeaponType.Direct:
                        TimeBeforeReload = ReloadTime;
                        return rnd.Next(0, 10) == 0 ? 0 : damage;
                    case EWeaponType.Explosive:
                        TimeBeforeReload = ReloadTime * 2;
                        return rnd.Next(0, 4) == 0 ? 0 : damage;
                    case EWeaponType.Guided:
                        return MinDamage;
                    default:
                        return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        //Moyenne des dégat de l'arme
        public double AverageDamage() => (MaxDamage + MinDamage) / 2.0;

        //Affiche les caractéristiques 
        public override string ToString()
        {
            return $"Name : {Name}\nMax Damage : {MaxDamage}\nMin Damage: {MinDamage}\nWeapon Type : {WeaponType}\n";
        }

    }
}