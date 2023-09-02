namespace Vrtic.Data.Model
{
    internal class Child : Person
    {

        public int ChildId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Child(int id, string jMB, string firstName, string lastName, DateTime dateOfBirth, string address, int height, int weight) : base(id, jMB, firstName, lastName, dateOfBirth, address)
        {
            ChildId = id;
            Height = height;
            Weight = weight;
        }

        public Child(string jMB, string firstName, string lastName, DateTime dateOfBirth, string address, int height, int weight) : base(jMB, firstName, lastName, dateOfBirth, address)
        {
            Height = height;
            Weight = weight;
        }

        public override bool Equals(object? obj)
        {
            return obj is Child child &&
                   base.Equals(obj) &&
                   Id == child.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
