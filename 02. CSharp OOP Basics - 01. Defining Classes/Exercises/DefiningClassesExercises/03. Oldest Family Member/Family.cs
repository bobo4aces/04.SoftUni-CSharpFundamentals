using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> People { get; set; }

    public Family()
    {
        this.People = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.People.OrderByDescending(n => n.Age).ToList()[0];
    }
}
