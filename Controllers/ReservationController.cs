using BookingHotel.DTO;
using BookingHotel.Models;
using BookingHotel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IRepositoryReservation repositoryReservation;
        private readonly IRepositoryRoom repositoryRoom;

        public ReservationController(IRepositoryReservation _repositoryReservation, IRepositoryRoom _repositoryRoom)
        {
            this.repositoryReservation = _repositoryReservation;
            this.repositoryRoom = _repositoryRoom;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = repositoryReservation.GetAll();
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound(new StatusResponse { Message = "No data found", Status = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}", Name = "getOneRouteReservation")]
        public IActionResult GetOne(int id)
        {
            try
            {
                var reservation = repositoryReservation.GetOne(id);
                if (reservation != null)
                {
                    return Ok(reservation);
                }
                return NotFound(new StatusResponse { Message = "faild no found this branch", Status = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int rowEffect = repositoryReservation.Delete(id);
                if (rowEffect > 0)
                {
                    return Ok(new StatusResponse { Message = $"Branch deleted", Status = true });
                }
                return BadRequest(new StatusResponse { Message = "Not found any branch", Status = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Insert(ReservationDto model)
        {
            Room room;
            double sumTotalPrice = 0;
            Reservation newreservation = new Reservation();
            try
            {
                if (ModelState.IsValid)
                {
                    newreservation.Guest_Id = model.Guest_Id;
                    newreservation.DateIn = DateTime.Now;
                    foreach (var item in model.ReservationRoomInfo)
                    {
                        room = repositoryRoom.GetOne(item.Room_Id);
                        newreservation.ReservationRooms.Add(new ReservationRoom
                        {
                            Room_Id = item.Room_Id,
                            DateIn = item.DateIn,
                            TotalPriceForOneRoom = item.NumberOfDays * room.Price,
                            NumberOfDays = item.NumberOfDays,
                            DateOut = item.DateOut,
                        });

                        sumTotalPrice += item.NumberOfDays * room.Price;
                    }
                    newreservation.TotalPrice = sumTotalPrice;
                    return Ok(repositoryReservation.Add(newreservation));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Edit(int id, Reservation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int rowEffect = repositoryReservation.Edit(id, model);
                    if (rowEffect > 0)
                    {
                        string url = Url.Link("getOneRouteReservation", new { id = id });
                        return Created(url, model);
                    }
                }
                return BadRequest(new StatusResponse { Message = "Edit faild", Status = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ConfirmReservation")]
        public IActionResult  ConfirmReservation(int reservationId)
        {
            try
            {
                var result = repositoryReservation.ConfirmReservation(reservationId);
                if(result.Status == true)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CancleReservation")]
        public IActionResult CancleReservation(int reservationId , int roomId )
        {
            try
            {
                var result = repositoryReservation.CancleReservation(reservationId,roomId);
                if (result)
                {
                    return Ok(new StatusResponse { Message ="Cancel success",Status=true});
                }
                return BadRequest(new StatusResponse { Message="Cancel faild",Status=false});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
