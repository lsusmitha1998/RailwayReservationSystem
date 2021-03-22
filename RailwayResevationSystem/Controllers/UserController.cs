using RailwayResevationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace RailwayResevationSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ReservationContext con = new ReservationContext();
        public ActionResult UserPage()
        {
            return View();
        }
        public ActionResult Index(User user)
        {
            return View(user);
        }
        public ActionResult Register()
        {
            User u = new User();
            return View(u);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                con.Users.Add(user);
                con.SaveChanges();
                //return View();
                
                //Response.Write("<script>alert('Registered successfully')</script>");
                return RedirectToAction("Login", "User",new { msg="success"});
            }

            return View(user);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = con.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = con.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Check/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Password,FirstName,LastName,Gender,DateOfBirth,Email,ContactNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                con.Entry(user).State = EntityState.Modified;
                con.SaveChanges();
                return RedirectToAction("Index", user);
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            User u = new User();
            return View(u);
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            bool isuser = con.Users.Any(u => u.UserId == user.UserId && u.Password == user.Password);
            var userDetails = con.Users.Where(u => u.UserId == user.UserId && u.Password == user.Password).FirstOrDefault();
                       
            if (isuser)
            {
                //FormsAuthentication.SetAuthCookie("", true);
                Session["User"] = userDetails.UserId;
                return RedirectToAction("FindTrain", "TrainUser");
            }
            else
            {
                if (con.Users.Any(u => u.UserId == user.UserId && u.Password != user.Password))
                {
                    //var us = con.Users.Where(u => u.UserId == user.UserId);
                    ModelState.AddModelError("", "User Id and password doesnot match!");
                }
                else if (!isuser)
                {
                    ModelState.AddModelError("", "Not a user! Please click on NEW USER to register");
                }
                return View();
            }
        }
        [HttpGet]
        public ActionResult MyBookings()
        {
            return View();
        }
        [HttpPost]       
        public ActionResult MyBookings(FormCollection form)
        {
            ViewBag.name = form["userid"].ToString(); 
            string userid = form["userid"].ToString();
            var mytickets = con.MyTickets.Where(t => t.UserId == userid).ToList();
            if(mytickets?.Any()!= true)
            {
                return View("NoBooking");
            }
            else
            {
                return View("MyBook", mytickets);
            }
            
            //var mybookings = con.MyBookings.Where(b => b.UserId == userid).ToList();
            //return View("Mybook",mybookings);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        public ActionResult Cancel(int? id)
        {
            var user = con.MyTickets.Find(id);
            int trainid = user.TrainId;
            var train = con.Trains.Where(t => t.TrainId == trainid).FirstOrDefault();
            var bookedtrain = con.BookTickets.Where(t => t.UserId == user.UserId && t.TrainId == user.TrainId && t.NoOfTickets == user.NoofTickets).FirstOrDefault();
            DateTime traintime = train.DateOfTravel;
            //DateTime bookedtime = user.DateOfBooking;
            //TimeSpan ts = DateTime.Now - user.DateOfBooking;
            TimeSpan ts = traintime - DateTime.Now;
            var diff = ts.TotalHours;
            double price = user.Price;
            string status = user.ConfirmationStatus;
            double refund = 0;
            if(status == "Waiting")
            {
                refund = price;
            }
            else
            {
                if (diff < 1)
                {
                    refund = 0;
                }
                else if (diff >= 1 && diff < 2)
                {
                    refund = 0.5 * price;
                }
                else if (diff >= 2 && diff < 24)
                {
                    refund = 0.7 * price;
                }
                else if (diff >= 24 && diff < 48)
                {
                    refund = 0.8 * price;
                }
                else
                {
                    refund = 0.9 * price;
                }

            }

            
            
            ViewBag.refund = refund;
            Session["refund"] = refund;
            con.MyTickets.Remove(user);
            bookedtrain.CancelledDate = DateTime.Now;
            //con.BookTickets.Remove(bookedtrain);
            var payeddata = con.Payments.Where(p => p.CardNo == user.CardNo).FirstOrDefault();
            payeddata.AvailableBalance = payeddata.AvailableBalance + refund;
            //waiting list
            int seats = user.NoofTickets;
            int waitmore = 0;
            
           
                var userup = con.MyTickets.Where(t => t.ConfirmationStatus == "Waiting").OrderBy(t => t.DateOfBooking).ToList();
            foreach(var item in userup)
            {
                if (item.NoofTickets <= seats)
                {
                    item.ConfirmationStatus = "Confirmed";
                    seats = seats - item.NoofTickets;
                }
                else
                {
                    item.ConfirmationStatus = "Waiting";
                    waitmore = seats;
                }
            }
            if(userup?.Any()!=true)
            {
                train.NoOfSeat = train.NoOfSeat + seats;
            }
            /*if (userup.NoofTickets <= seats)
                {
                    userup.ConfirmationStatus = "Booked";
                    seats = seats - userup.NoofTickets;
                }
                else
                {
                    userup.ConfirmationStatus = "Waiting";
                    waitmore = seats;
                }*/

            train.NoOfSeat = train.NoOfSeat + seats;
            train.NoOfSeat = train.NoOfSeat + waitmore;
            if(train.NoOfSeat>0)
            {
                train.SeatAvailability = "available";
            }
            con.SaveChanges();
            return View();
        }        
        public ActionResult PaymentDetails()
        {
            if(Session["User"] != null)
            {

                string userid = (string)Session["User"];
                var paylist = con.BookTickets.Where(p => p.UserId == userid).ToList();
                if(paylist?.Any() != true)
                {
                    //Response.Write("<center><h2 style="+"color:red"+">You have not done any payments yet</h2></center>");

                    return RedirectToAction("FindTrain","TrainUser",new { msg = "nopay"});
                }
                else
                {
                    return View(paylist);
                }
                
            }
            else
            {                
                return RedirectToAction("Login","User");
            }
            
        }

    }
}