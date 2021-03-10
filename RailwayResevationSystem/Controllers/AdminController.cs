using RailwayResevationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayResevationSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ReservationContext con = new ReservationContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(Admin adm)
        {
            var adminDetails = con.Admins.Where(a => a.UserId == adm.UserId && a.password == adm.password).FirstOrDefault();
            bool isadmin = con.Admins.Any(a => a.UserId == adm.UserId && a.password == adm.password);
            if (isadmin)
            {
                Session["adminId"] = adminDetails.UserId;
                return RedirectToAction("AdminPage");
            }
            else
            {
                if (con.Admins.Any(a => a.UserId == adm.UserId && a.password != adm.password))
                {
                    ModelState.AddModelError("", "User Id and password doesnot match");
                }
                else if (!isadmin)
                {
                    ModelState.AddModelError("", "Not an Admin!");
                }
                return View();
            }

        }        
        public ActionResult AdminPage()
        {
            if(Session["adminId"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Adminlogin", "Admin");
            }
        }

    }
}