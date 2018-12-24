using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Meat : Food, IFood
    {
        public Meat(int quantity)
            :base(quantity)
        {
        }
    }
}