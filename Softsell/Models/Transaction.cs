namespace Softsell.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int GuestID { get; set; }
        public Guest Guest { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
