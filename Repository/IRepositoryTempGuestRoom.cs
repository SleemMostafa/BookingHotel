﻿using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public interface IRepositoryTempGuestRoom:IRepository<TempGuestRooms,int>
    {
        bool CheckIfTempRoomExit(int roomId, string guestId);

    }
}
