﻿using BookingHotel.Models;
using BookingHotel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempGuestRoomController : ControllerBase
    {
        private readonly IRepositoryTempGuestRoom repositoryTempGuestRoom;

        public TempGuestRoomController(IRepositoryTempGuestRoom repositoryTempGuestRoom)
        {
            this.repositoryTempGuestRoom = repositoryTempGuestRoom;
        }
        [HttpPost]
        public IActionResult Insert(TempGuestRooms model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repositoryTempGuestRoom.Add(model);
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult CheckTempRoomExist(int roomId,string guestId)
        {
            try
            {
                var data = repositoryTempGuestRoom.CheckIfTempRoomExit(roomId, guestId);
                if(data)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
