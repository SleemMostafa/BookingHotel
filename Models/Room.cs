﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel.Models
{
    public enum StatusRoom
    {
        Available,
        Booked,
    }
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public StatusRoom Status{ get; set; }
        [ForeignKey("Branch")]
        [Required]
        public int Branch_Id{ get; set; }
        public virtual Branch  Branch { get; set; }
        [ForeignKey("Room_Type")]
        [Required]
        public int RoomTypeId { get; set; }
        public virtual RoomType Room_Type { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}