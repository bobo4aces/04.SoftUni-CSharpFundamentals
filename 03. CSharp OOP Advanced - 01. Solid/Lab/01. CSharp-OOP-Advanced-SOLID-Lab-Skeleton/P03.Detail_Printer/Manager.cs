using P03.Detail_Printer.Contacts;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nDocuments:\n{string.Join(Environment.NewLine, this.Documents)}";
        }
    }
}
