using Microsoft.EntityFrameworkCore;
using Softsell.Models;

namespace Softsell.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
