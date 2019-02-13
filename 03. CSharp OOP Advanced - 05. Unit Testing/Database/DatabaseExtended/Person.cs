namespace DatabaseExtended
{
    public class Person
    {
        public long Id { get; private set; }
        public string Username { get; private set; }

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }
    }
}
