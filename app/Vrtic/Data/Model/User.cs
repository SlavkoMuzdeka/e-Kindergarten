namespace Vrtic.Data.Model
{
    internal class User : Person
    {
        public int PersonId { get; set; }
        public int Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public User(int id, string jMB, string firstName, string lastName, DateTime dateOfBirth, string address, int salary) : base(id, jMB, firstName, lastName, dateOfBirth, address)
        {
            PersonId = id; 
            Salary = salary;
        }

        public User(int personId, int salary,string userName, string password):base(personId)
        {
            Salary = salary;
            UserName = userName;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   base.Equals(obj) &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
