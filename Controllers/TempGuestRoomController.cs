using BookingHotel.DTO;
using BookingHotel.Models;
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
        [HttpGet("GetAllTempByGuestId")]
        public IActionResult GetAllTempByGuestId(string guestId)
        {
            try
            {
                var data = repositoryTempGuestRoom.GetAllForGuest(guestId);
                if(data != null)
                {
                    return Ok(data);
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTempRoomByID")]
        public IActionResult GetTempRoomByID(int id)
        {
            try
            {
                var data = repositoryTempGuestRoom.GetOne(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTempRoomByID")]
        public IActionResult DeleteTempRoomByID(int id)
        {
            try
            {
                var data = repositoryTempGuestRoom.Delete(id);
                if (data > 0)
                {
                    return Ok(new StatusResponse { Message="Delete succsess",Status =  true});
                }
                return BadRequest(new StatusResponse { Message = "Delete faild", Status = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert(TempGuestRoomDto model)
        {
            TempGuestRooms newTempGuestRooms = new TempGuestRooms();
            newTempGuestRooms.DateIn = model.DateIn;
            newTempGuestRooms.DateOut = model.DateIn;
            newTempGuestRooms.NumberOfDays = model.NumberOfDays;
            newTempGuestRooms.RoomId = model.RoomId;
            newTempGuestRooms.GuestId = model.GuestId;
            try
            {
                if(ModelState.IsValid)
                {
                    repositoryTempGuestRoom.Add(newTempGuestRooms);
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Edit(int id, TempRoomDTO tempGuestRooms)
        {
            try
            {
                var data = repositoryTempGuestRoom.EditTempRoom(id, tempGuestRooms);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
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
        [HttpDelete]
        public IActionResult DeleteByGuestID(string id)
        {
            try
            {
                var data = repositoryTempGuestRoom.DeleteByGuestID(id);
                if (data > 1)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
