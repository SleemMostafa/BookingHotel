using System.ComponentModel.DataAnnotations;

namespace BookingHotel.DTO
{
    public class ReservationRoomDto
    {
        public int Room_Id { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateIn { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateOut { get; set; }
        public int NumberOfDays { get; set; }
    }
}
