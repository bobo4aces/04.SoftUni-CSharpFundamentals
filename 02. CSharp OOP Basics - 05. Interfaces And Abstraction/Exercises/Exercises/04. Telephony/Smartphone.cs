using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        private string site;
        private string phone;

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (!value.All(char.IsNumber))
                {
                    throw new ArgumentException("Invalid number!");
                }
                phone = value;
            }
        }
        public string Site
        {
            get
            {
                return site;
            }
            set
            {
                if (value.Any(char.IsNumber))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                site = value;
            }
        }
        public string Browsing(string site)
        {
            return $"Browsing: {site}!";
        }

        public string Calling(string number)
        {
            return $"Calling... {number}";
        }
    }
}
