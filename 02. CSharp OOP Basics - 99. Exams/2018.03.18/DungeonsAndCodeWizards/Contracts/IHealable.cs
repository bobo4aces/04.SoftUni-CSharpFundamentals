using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
