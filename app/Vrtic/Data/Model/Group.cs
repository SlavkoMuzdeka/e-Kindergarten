namespace Vrtic.Data.Model
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }

        public Group(int id, string name, int numberOfMembers)
        {
            Id = id;
            Name = name;
            NumberOfMembers = numberOfMembers;
        }

        public Group(string name, int numberOfMembers)
        {
            Name = name;
            NumberOfMembers = numberOfMembers;
        }

        public override bool Equals(object? obj)
        {
            return obj is Group group &&
                   Id == group.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
