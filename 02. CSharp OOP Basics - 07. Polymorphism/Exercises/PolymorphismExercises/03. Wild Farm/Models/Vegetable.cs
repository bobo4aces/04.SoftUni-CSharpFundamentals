using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Vegetable : Food, IFood
    {
        public Vegetable(int quantity)
            : base(quantity)
        {
        }
    }
}
