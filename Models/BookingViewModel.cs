namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class RateViewModel
    {
 
        public int hotel_id { get; set; }

        [Required]
        [Display(Name = "Rate this Hotel")]
        public int hotel_rate {get; set; }
    }
}
