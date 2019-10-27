using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MonashHotels_Assignment.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_MonashHotels_Assignment.Controllers
{
    public class BookingsController : Controller
    {
        private BookingModel db = new BookingModel();
        private Registerd_hotel_model dm = new Registerd_hotel_model();
        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Result = TempData["shortMessage"].ToString();
                    return View(db.Bookings.ToList());
                }
                else
                {
                    var userId = User.Identity.GetUserId();

                    var bookings = db.Bookings.Where(s => s.user_id == userId).ToList();
                    return View(bookings);
                }
            }
            catch
            {
                if (User.IsInRole("Admin"))
                {
                   return View(db.Bookings.ToList());
                }
                else
                {
                    var userId = User.Identity.GetUserId();

                    var bookings = db.Bookings.Where(s => s.user_id == userId).ToList();
                    return View(bookings);
                }
            }
            
            
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var model = new BookingViewModel
            {
                hotelList = dm.Hotel_Data.Select(p => new SelectListItem { Text = p.hotel_name, Value = p.hotel_id.ToString() }).ToList()
            };
            return View(model);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "booking_id,booking_start_date,booking_end_date,user_id,hotel_id,booking_places")] BookingViewModel booking)
        {


            if (ModelState.IsValid)
           {
                try
                {


                    Booking bk = new Booking();
                    bk.hotel_id = booking.hotel_id;
                    bk.booking_places = (int)booking.booking_places;
                    bk.booking_start_date = (System.DateTime) booking.booking_start_date;
                    bk.booking_end_date = (System.DateTime) booking.booking_end_date;
                    bk.user_id = User.Identity.GetUserId(); //booking.user_id;


                    db.Bookings.Add(bk);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                
                    var model = new BookingViewModel
                    {
                        hotelList = dm.Hotel_Data.Select(p => new SelectListItem { Text = p.hotel_name, Value = p.hotel_id.ToString() }).ToList()
                    };
                    ViewBag.Failure = "You already have a booking for that date. Please choose a different date";
                    return View(model);
                }
            }
            return View();
            
        }

        //GET: Bookins/Rate
        public ActionResult Rate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hotel_Data hotel = dm.Hotel_Data.Find(id);
            /*Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }*/
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(int? id, Hotel_Data hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel.hotel_rating != null )
                { 
                    //hotel.hotel_rating = 2;

                    Hotel_Data hotel2 = dm.Hotel_Data.Find(id);

                    var oldRating = hotel2.hotel_rating;
                    var noOfRatings = hotel2.hotel_no_of_ratings;
                    noOfRatings = noOfRatings + 1;

                    // calculating the new rating
                    var newRating = oldRating + ((hotel.hotel_rating - oldRating) / noOfRatings);


                    hotel2.hotel_no_of_ratings = hotel2.hotel_no_of_ratings + 1;

                    hotel2.hotel_rating = newRating;
                    //f.Name = NewName;
                    //myEntities.SaveChanges();


                    dm.SaveChanges();
                    db.SaveChanges();
                    /*db.Entry(booking).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");*/
                
                    //ViewBag.Result = "Thank you for rating " + hotel.hotel_name;

                    TempData["shortMessage"] = "Thank you for rating " + hotel2.hotel_name;
                }
                else
                {
                    ViewBag.Result = "Please select a rating";
                    return View(hotel);
                }
            }
            
            return RedirectToAction("Index");
        }


        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }





        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,booking_start_date,booking_end_date,user_id,hotel_id,booking_places")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
