﻿using System;
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
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
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
        public ActionResult Create([Bind(Include = "booking_id,booking_start_date,booking_end_date,user_id,hotel_id,booking_places")] BookingViewModel booking)
        {


            // if (ModelState.IsValid)
            //{
            try
            {


                Booking bk = new Booking();
                bk.hotel_id = booking.hotel_id;
                bk.booking_places = booking.booking_places;
                bk.booking_start_date = booking.booking_start_date;
                bk.booking_end_date = booking.booking_end_date;
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
            //}

            
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
