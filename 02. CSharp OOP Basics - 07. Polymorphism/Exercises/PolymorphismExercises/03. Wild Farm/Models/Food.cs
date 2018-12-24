using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
