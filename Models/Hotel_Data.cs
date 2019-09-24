namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hotel_Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int hotel_id { get; set; }

        [StringLength(50)]
        public string hotel_name { get; set; }

        [StringLength(50)]
        public string hotel_description { get; set; }

        [StringLength(50)]
        public string hotel_email { get; set; }

        public decimal? hotel_latitude { get; set; }

        public decimal? hotel_longitude { get; set; }

        [StringLength(50)]
        public string hotel_price { get; set; }

        [StringLength(50)]
        public string hotel_address { get; set; }
    }
}
