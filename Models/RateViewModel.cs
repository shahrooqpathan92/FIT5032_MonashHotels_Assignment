namespace FIT5032_MonashHotels_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public class BookingViewModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public int booking_id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Booking Start Date")]
        public DateTime? booking_start_date { get; set; }


        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Booking End Date")]
        public DateTime? booking_end_date { get; set; }

       /* [Required]
        [Display(Name = "User id")]
        public string user_id { get; set; }*/

        //public ICollection<Hotel_Data> hotel_id { get; set; }
        public int hotel_id { get; set; }
        public List<SelectListItem> hotelList { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Please enter a value bigger than {1} and less than {2}")]
        // []
       // [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Display(Name = "No. of people staying")]
        public int? booking_places { get; set; }
    }
}
