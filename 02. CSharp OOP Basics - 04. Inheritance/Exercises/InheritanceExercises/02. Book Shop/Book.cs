using System;
using System.Linq;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                string[] fullName = value
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
                if (fullName.Length < 2)
                {
                    this.author = value;
                    return;
                }
                if (char.IsDigit(fullName[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }
        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            internal set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public override string ToString()
        {
            return $"Type: Book\nTitle: {this.Title}\nAuthor: {this.Author}\nPrice: {this.Price:f2}";
        }
    }
}
