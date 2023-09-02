namespace Vrtic.Data.Model
{
    internal class Person
    {
        public int Id { get; set; }
        public string JMB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public Person(string jMB, string firstName, string lastName, DateTime dateOfBirth, string address)
        {
            JMB = jMB;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public Person(int id, string jMB, string firstName, string lastName, DateTime dateOfBirth, string address)
        {
            Id = id;
            JMB = jMB;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public Person(int id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Id == person.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
