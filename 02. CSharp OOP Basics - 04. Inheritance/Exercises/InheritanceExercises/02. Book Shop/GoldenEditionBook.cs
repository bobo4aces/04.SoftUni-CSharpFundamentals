using System;
using System.Text;

namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        public override decimal Price
        {
            get => base.Price;
            internal set => base.Price = value * 1.3m;
        }

        public GoldenEditionBook(string author, string title, decimal price) 
            : base(author, title, price)
        {

        }

        public override string ToString()
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;

        }
    }
}
