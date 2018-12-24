using System.Collections.Generic;

namespace Hospital
{
    public class Room
    {
        public int Number { get; set; }
        public List<Patient> Patients { get; set; }

        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public Room(int number) : this()
        {
            Number = number;
        }
    }
}
