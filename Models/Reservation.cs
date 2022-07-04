using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [DataType("Date")]
        public DateTime DateIn { get; set; }
        [DataType("Date")]
        public DateTime DateOut { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
