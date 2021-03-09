using RailwayResevationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RailwayResevationSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ReservationContext con = new ReservationContext();
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
                return RedirectToAction("Index", user);
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
            if (isuser)
            {
                FormsAuthentication.SetAuthCookie("", true);
                return RedirectToAction("afterlogin");
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
        [Authorize]
        public ActionResult afterlogin()
        {
            return View();
        }

    }
}