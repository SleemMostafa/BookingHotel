using BookingHotel.DTO;
using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public interface IRepositoryReservation:IRepository<Reservation,int>
    {
        StatusResponse ConfirmReservation(int reservationId);
        bool CancleReservation(int reservationId, int roomId);
    }
}
