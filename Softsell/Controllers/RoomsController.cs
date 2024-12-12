using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softsell.Data;
using Softsell.Models;

namespace Softsell.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelContext _context;

        public RoomsController(HotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var availableRooms = await _context.Rooms.Where(r => r.Status == "Available").ToListAsync();
            return View(availableRooms);
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(int roomId, string guestName)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null && room.Status == "Available")
            {
                var guest = new Guest
                {
                    Name = guestName,
                    CheckInDate = DateTime.Now,
                    RoomID = roomId
                };

                room.Status = "Occupied";
                _context.Add(guest);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Error");
        }
    }
}
