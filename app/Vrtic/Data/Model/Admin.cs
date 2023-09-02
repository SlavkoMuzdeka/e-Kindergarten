namespace Vrtic.Data.Model
{
    internal class Admin : Person
    {

        public int AdministratorId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public Admin(int id, string jMB, string firstName, string lastName, DateTime dateOfBirth, string address, string userName, string password) : base(id, jMB, firstName, lastName, dateOfBirth, address)
        {
            AdministratorId = id;
            UserName = userName;
            Password = password;
        }

        public Admin(string jMB, string firstName, string lastName, DateTime dateOfBirth, string address,string userName, string password) : base(jMB, firstName, lastName, dateOfBirth, address)
        {
            UserName = userName;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            return obj is Admin admin &&
                   base.Equals(obj) &&
                   Id == admin.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
