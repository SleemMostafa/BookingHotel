using BookingHotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room : ControllerBase
    {
        ApplicationContext db;
        public Room(ApplicationContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query = db.Branches.ToList();
            foreach (var item in query)
            {
                db.Entry(item).Collection(r => r.Rooms).Load();
            }
            return Ok(query);
        }
    }
}
