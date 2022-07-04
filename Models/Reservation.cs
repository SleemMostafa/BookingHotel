using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [DataType("Date"),Required]
        public DateTime DateIn { get; set; }
        [DataType("Date"),Required]
        public DateTime DateOut { get; set; }
        [Required]
        public bool Status { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        [ForeignKey("Guest"),Required]
        public string Guest_Id { get; set; }
        public virtual Guest Guest { get; set; }

    }
}
