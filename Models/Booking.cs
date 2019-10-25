namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int booking_id { get; set; }

        public DateTime booking_start_date { get; set; }

        public DateTime booking_end_date { get; set; }

        [Required]
        [StringLength(128)]
        public string user_id { get; set; }

        public int hotel_id { get; set; }

        public int booking_places { get; set; }
    }
}
