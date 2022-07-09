﻿using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public class TempGuestRoomRepository : IRepositoryTempGuestRoom
    {
        private readonly ApplicationContext db;

        public TempGuestRoomRepository(ApplicationContext _db)
        {
            db = _db;
        }
        public TempGuestRooms Add(TempGuestRooms entity)
        {
            if(entity != null)
            {
                db.TempGuestRooms.Add(entity);
                db.SaveChanges();
                return entity;
            }
            throw new Exception("Add faild");
        }

        public int Delete(int id)
        {
            var data = db.TempGuestRooms.FirstOrDefault(t => t.Id == id);
            if(data != null)
            {
                db.TempGuestRooms.Remove(data);
                return (db.SaveChanges());
            }
            return 0;
        }

        public int Edit(int id, TempGuestRooms entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<TempGuestRooms> GetAll()
        {
            throw new NotImplementedException();
        }

        public TempGuestRooms GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}