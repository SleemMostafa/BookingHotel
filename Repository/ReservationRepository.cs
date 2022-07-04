using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public class ReservationRepository : IRepositoryReservation
    {
        private readonly ApplicationContext db;

        public ReservationRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public Reservation Add(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reservation GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
