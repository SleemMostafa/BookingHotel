using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public class RoomRepository : IRepositoryRoom
    {
        private readonly ApplicationContext db;

        public RoomRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public Room Add(Room entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public Room GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
