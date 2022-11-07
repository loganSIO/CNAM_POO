namespace LE_NEVEZ_Logan_Tp1
{
    public interface ISpaceship
    {
        string Name { get; set; }
        int Structure { get; set; }
        int Shield { get; set; }
        bool IsDestroyed { get; set; }
        List<Weapon> Weapons { get; }
        int CurrentStructure { get; set; }
        int CurrentShield { get; set; }
        void TakeDamage(int damage);
        void ShootTarget(Spaceship target);
        void AddWeapon(Weapon weapon);
        void RemoveWeapon(Weapon oWeapon);
        void ClearWeapons();
        void ViewShip();
        void ViewWeapons();
        
    }
}
