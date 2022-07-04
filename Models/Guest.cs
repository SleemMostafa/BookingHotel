using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Guest:IdentityUser
    {
        [Required]
        public string Address { get; set; }
    }
}
