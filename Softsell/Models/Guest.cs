namespace Softsell.Models
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
