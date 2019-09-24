namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Registerd_hotel_model : DbContext
    {
        public Registerd_hotel_model()
            : base("name=Registerd_hotel_model")
        {
        }

        public virtual DbSet<Hotel_Data> Hotel_Data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_name)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_description)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_email)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_price)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel_Data>()
                .Property(e => e.hotel_address)
                .IsUnicode(false);
        }
    }
}
