namespace Softsell.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int TransactionID { get; set; }
        public Transaction Transaction { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
