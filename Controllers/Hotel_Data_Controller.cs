using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MonashHotels_Assignment.Models;

namespace FIT5032_MonashHotels_Assignment.Controllers
{
    public class Hotel_Data_Controller : Controller
    {
        private Registerd_hotel_model db = new Registerd_hotel_model();

        // GET: Hotel_Data_
        public ActionResult Index()
        {
            return View(db.Hotel_Data.ToList());
        }

        //GET: Hotel_Data_/Map
        public ActionResult Map()
        {
            return View(db.Hotel_Data.ToList());
        }

        // GET: Hotel_Data_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Data hotel_Data = db.Hotel_Data.Find(id);
            if (hotel_Data == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Data);
        }

        // GET: Hotel_Data_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel_Data_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hotel_id,hotel_name,hotel_description,hotel_email,hotel_latitude,hotel_longitude,hotel_price,hotel_address")] Hotel_Data hotel_Data)
        {
            if (ModelState.IsValid)
            {
                db.Hotel_Data.Add(hotel_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel_Data);
        }

        // GET: Hotel_Data_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Data hotel_Data = db.Hotel_Data.Find(id);
            if (hotel_Data == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Data);
        }

        // POST: Hotel_Data_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hotel_id,hotel_name,hotel_description,hotel_email,hotel_latitude,hotel_longitude,hotel_price,hotel_address")] Hotel_Data hotel_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel_Data);
        }

        // GET: Hotel_Data_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Data hotel_Data = db.Hotel_Data.Find(id);
            if (hotel_Data == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Data);
        }

        // POST: Hotel_Data_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel_Data hotel_Data = db.Hotel_Data.Find(id);
            db.Hotel_Data.Remove(hotel_Data);
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
