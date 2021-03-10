using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RailwayResevationSystem.Models;

namespace RailwayResevationSystem.Controllers
{
    public class TrainSchedulesController : Controller
    {
        private ReservationContext db = new ReservationContext();

        // GET: TrainSchedules
        public ActionResult Index()
        {
            return View(db.TrainSchedules.ToList());
        }

        // GET: TrainSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // GET: TrainSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainId,Stop,ArrivalTime")] TrainSchedule trainSchedule)
        {
            if (ModelState.IsValid)
            {
                db.TrainSchedules.Add(trainSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainSchedule);
        }

        // GET: TrainSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainId,Stop,ArrivalTime")] TrainSchedule trainSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainSchedule);
        }

        // GET: TrainSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            db.TrainSchedules.Remove(trainSchedule);
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
