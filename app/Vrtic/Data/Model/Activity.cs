namespace Vrtic.Data.Model
{
    internal class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Activity(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            return obj is Activity activity &&
                   Id == activity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
