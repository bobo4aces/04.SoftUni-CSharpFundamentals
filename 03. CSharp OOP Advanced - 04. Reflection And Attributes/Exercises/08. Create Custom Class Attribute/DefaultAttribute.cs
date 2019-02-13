using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Create_Custom_Class_Attribute
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class DefaultAttribute : Attribute
    {
        public DefaultAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; private set; }
        public int Revision { get; private set; }
        public string Description { get; private set; }
        public string[] Reviewers { get; private set; }
    }
}
