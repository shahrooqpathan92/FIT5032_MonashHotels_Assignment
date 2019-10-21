namespace FIT5032_MonashHotels_Assignment.Models
{
    using SendGrid.Helpers.Mail;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class SendBulkEmailViewModel
    {
        public string tos { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the contents")]
        public string Contents { get; set; }
    }

}