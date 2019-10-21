using FIT5032_MonashHotels_Assignment.Models;
using FIT5032_MonashHotels_Assignment.Utils;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_MonashHotels_Assignment.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Bulk_Email()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Send_Bulk_Email(SendBulkEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var toss = model.tos;
                    Console.WriteLine(model.tos);
                    var tos = new List<EmailAddress>
                    {
                        new EmailAddress("shahrooq.pathan@gmail.com", "Example User1"),
                        new EmailAddress("spat0023@student.monash.edu", "Example User2"),
          
                    };
                    String subject = model.Subject;
                    String contents = model.Contents;
                    EmailSender es = new EmailSender();
                    es.Send_To_Many(tos, subject, contents);
                    ViewBag.Result = "Email sent to Receipents" + tos;

                    ModelState.Clear();

                    return View(new SendBulkEmailViewModel());
                }
                catch
                {
                    ViewBag.Result = "Error Sending Email";
                    return View();
                }
            }

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    Console.WriteLine(contents);

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email sent to " +toEmail;

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}