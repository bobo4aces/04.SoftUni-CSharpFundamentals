using WildFarm.Contracts;

namespace WildFarm.Models
{
    public class Seeds : Food, IFood
    {
        public Seeds(int quantity)
            :base(quantity)
        {
        }
    }
}