namespace Vrtic.Data.Model
{
    internal class MembershipFee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime MonthToPay { get; set; }
        public int ChildId { get; set; }
        public DateTime DateOfPayment { get; set; }

        public MembershipFee(int id, string type, int amount, bool isPaid, DateTime monthToPay, DateTime dateOfPayment)
        {
            Id = id;
            Type = type;
            Amount = amount;
            IsPaid = isPaid;
            MonthToPay = monthToPay;
            DateOfPayment = dateOfPayment;
        }

        public MembershipFee(int id, string type, int amount, bool isPaid, DateTime monthToPay)
        {
            Id = id;
            Type = type;
            Amount = amount;
            IsPaid = isPaid;
            MonthToPay = monthToPay;
        }

        public MembershipFee(string type, int amount, bool isPaid, DateTime monthToPay, int childId)
        {
            Type = type;
            Amount = amount;
            IsPaid = isPaid;
            MonthToPay = monthToPay;
            ChildId = childId;
        }

        public override bool Equals(object? obj)
        {
            return obj is MembershipFee payment &&
                   Id == payment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
