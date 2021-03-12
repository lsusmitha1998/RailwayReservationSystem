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
                TempData.Keep();
                con.BookTickets.Add(booked);
                //tickets reduceded from train
                //details added to mytickets
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
