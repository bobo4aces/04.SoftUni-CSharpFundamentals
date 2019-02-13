namespace _07._Inferno_Infinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponRearity, string weaponType, string weaponName);
    }
}
