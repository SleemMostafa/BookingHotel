using System.ComponentModel.DataAnnotations;

namespace BookingHotel.DTO
{
    public class TempGuestRoomDto
    {
        [Required]
        public int NumberOfDays { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateIn { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateOut { get; set; }
        public string GuestId { get; set; }
        public int RoomId { get; set; }
    }
}
