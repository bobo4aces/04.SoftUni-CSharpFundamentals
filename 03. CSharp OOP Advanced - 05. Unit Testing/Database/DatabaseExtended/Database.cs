using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseExtended
{
    public class Database
    {
        private const int capacity = 16;
        private Person[] array;
        public int CurrentLength { get; private set; }

        public Database(params Person[] people)
        {
            this.array = new Person[capacity];
            this.SetArray(people);
        }

        private void SetArray(params Person[] people)
        {
            people.CopyTo(this.array, 0);
            this.CurrentLength = people.Length;
        }

        public void Add(Person person)
        {
            if (this.CurrentLength + 1 >= capacity)
            {
                throw new InvalidOperationException("The array must contains no more than 16 elements!");
            }
            Person personWithSameUsername = this.array.FirstOrDefault(p => p?.Username == person?.Username);
            if (personWithSameUsername != null)
            {
                throw new InvalidOperationException("Person with the same username already exists!");
            }
            Person personWithSameId = this.array.FirstOrDefault(p => p?.Id == person?.Id);
            if (personWithSameId != null)
            {
                throw new InvalidOperationException("Person with the same id already exists!");
            }
            this.array[this.CurrentLength++] = person;
        }

        public void Remove()
        {
            if (this.CurrentLength == 0)
            {
                throw new InvalidOperationException("The database is empty!");
            }
            this.array[this.CurrentLength--] = null;
        }

        public Person[] Fetch()
        {
            return this.array.Take(this.CurrentLength).ToArray();
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be positive number");
            }

            Person person =  this.array.FirstOrDefault(p => p?.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException("There is no person with this id!");
            }

            return person;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username is invalid!");
            }

            Person person = this.array.FirstOrDefault(p => p?.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException("There is no person with this username!");
            }

            return person;
        }
    }
}
