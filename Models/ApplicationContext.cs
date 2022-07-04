using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Models
{
    public class ApplicationContext:IdentityDbContext<Guest>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }

        public  DbSet<Branch> Branches { get; set; }
        public  DbSet<Reservation> Reservations { get; set; }
        public  DbSet<Room> Rooms { get; set; }
        public  DbSet<RoomType>  RoomTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Branch>().Property(b => b.Name).IsRequired();
            //builder.Entity<Branch>().ToTable("Branch");
            //builder.Entity<Branch>().HasMany<Room>().WithOne().HasForeignKey("Branch_Id");

            base.OnModelCreating(builder);
        }
    }
}
