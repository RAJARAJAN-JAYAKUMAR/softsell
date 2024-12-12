using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softsell.Data;
using Softsell.Models;

namespace Softsell.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly HotelContext _context;

        public TransactionsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions.Include(t => t.Guest).Include(t => t.Room).ToListAsync();
            return View(transactions);
        }

        // POST: Transactions/CheckOut
        [HttpPost]
        public async Task<IActionResult> CheckOut(int guestId)
        {
            var guest = await _context.Guests.Include(g => g.Room).FirstOrDefaultAsync(g => g.GuestID == guestId);
            if (guest != null)
            {
                guest.CheckOutDate = DateTime.Now;
                guest.Room.Status = "Available";
                _context.Update(guest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to Transaction screen
            }

            return View("Error"); // Handle guest not found
        }
    }
}

