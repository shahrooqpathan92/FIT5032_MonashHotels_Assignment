namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingModel : DbContext
    {
        public BookingModel()
            : base("name=BookingModel")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
