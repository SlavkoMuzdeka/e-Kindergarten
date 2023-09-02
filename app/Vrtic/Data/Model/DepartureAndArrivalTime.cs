namespace Vrtic.Data.Model
{
    internal class DepartureAndArrivalTime
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public DateTime RecordedTime { get; set; }
        public int Type { get; set; }

        public DepartureAndArrivalTime(int id, int childId, DateTime recordedTime, int type)
        {
            Id = id;
            ChildId = childId;
            RecordedTime = recordedTime;
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            return obj is DepartureAndArrivalTime time &&
                   Id == time.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
