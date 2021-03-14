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
    public class PaymentsController : Controller
    {
        private ReservationContext con = new ReservationContext();

        // GET: Payments
        public ActionResult Index()
        {
            return View(con.Payments.ToList());
        }

        // GET: Payments/Details/5
        

        // GET: Payments/Create
        public ActionResult Create()
        {
            TempData["booking1"] = TempData["booking"];
            TempData.Keep();
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CardNo,CardHolder,ExpiryDate,Cvv,CardType")] Payment payment)
        {
           
            var pay = con.Payments.Where(p => p.CardNo.Equals(payment.CardNo) && p.CardHolder.Equals(payment.CardHolder) && p.CardType == payment.CardType &&
            p.ExpiryDate == payment.ExpiryDate && p.Cvv == payment.Cvv ).FirstOrDefault();
            if(pay != null)
            {
                pay.AvailableBalance = (pay.AvailableBalance - (double)Session["Price"]);
                BookTicket booked = (BookTicket)TempData["booking1"];
                booked.CardNo = pay.CardNo;
                booked.BookedDate = DateTime.Now;
                TempData.Keep();
                con.BookTickets.Add(booked);
                //tickets reduced from train
                int tid = booked.TrainId;
                string uid = booked.UserId;
                var train = con.Trains.Where(t => t.TrainId == tid).FirstOrDefault();
                if(train.NoOfSeat>0)
                {
                    train.NoOfSeat = (train.NoOfSeat - booked.NoOfTickets);
                }
                else
                {
                    train.NoOfSeat = 0;
                    int waiting = booked.NoOfTickets;
                }
                int noofseats = train.NoOfSeat;
                if (noofseats == 0)
                {
                    train.SeatAvailability = "waiting";
                   // int i = 0;
                    train.NoOfSeat = 0;
                }
                
                
                
                //adding to user booking
                string status = train.SeatAvailability;
                var mytickets = new MyTicket();
                mytickets.UserId = uid;
                mytickets.TrainId = tid;
                mytickets.Source = train.Source;
                mytickets.Destination = train.Destination;
                mytickets.NoofTickets = booked.NoOfTickets;
                mytickets.Price = booked.Price;
                mytickets.DateOfBooking =DateTime.Now;
                mytickets.CardNo = pay.CardNo;
                string sts;
                if(status == "Available" ||status == "available")
                    {
                    sts = "confirmed";
                }
                else
                {
                    sts = "Waiting";
                }
                mytickets.ConfirmationStatus = sts;
                con.MyTickets.Add(mytickets);                
                //add col cardno,bookdate in booktickets
                con.SaveChanges();
                return RedirectToAction("PaySuccess");
            }
            else
            {                
                return RedirectToAction("Fail");
            }
        }
        public ActionResult Fail()
        {
            return RedirectToAction("Create", new { msg = "fail" });
        }
        public ActionResult PaySuccess()
        {
            return View();
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                con.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
