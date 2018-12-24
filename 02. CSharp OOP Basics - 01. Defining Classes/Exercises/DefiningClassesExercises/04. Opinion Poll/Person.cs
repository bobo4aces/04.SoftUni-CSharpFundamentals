using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }
    public Person(int age) : this()
    {
        this.Age = age;
    }
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public static List<Person> GetPersons(List<Person> persons)
    {
        return persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
    }
}