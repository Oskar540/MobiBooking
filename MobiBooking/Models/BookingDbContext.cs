using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MobiBooking.Models
{
    public class BookingDbContext : IdentityDbContext
    {
        public BookingDbContext(DbContextOptions opts) : base(opts)
        {
        }

        public BookingDbContext() : base()
        {
        }

        public new DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}