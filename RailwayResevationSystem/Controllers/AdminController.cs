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
       public ActionResult Useridrecovery()
        {
            Admin admin = new Admin();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Useridrecovery(Admin admin)
        {

            var idrecovery = con.Admins.Where(u => u.Petname == admin.Petname && u.PhoneNumber == admin.PhoneNumber && u.Email == admin.Email).FirstOrDefault();

            bool iscorrect = con.Admins.Any(p => p.PhoneNumber == admin.PhoneNumber && p.Email == admin.Email && p.Petname == admin.Petname);

            if (iscorrect)
            {
                Session["userecovery"] = idrecovery.UserId;
                return RedirectToAction("Userid");
            }
            else
            {

                ModelState.AddModelError("", "Enter Correct Details");

            }
            return View();

        }
       public ActionResult Userid()
        {
            return View();
        }
        public ActionResult Passwordrecovery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Passwordrecovery(Admin admin)
        {
            var passrec = con.Admins.Where(p => p.UserId == admin.UserId && p.Petname == admin.Petname).FirstOrDefault();
            bool ispass = con.Admins.Any(p => p.UserId == admin.UserId && p.Petname == admin.Petname);
            if (ispass)
            {
                Session["passrecovery"] = passrec.UserId;
                return RedirectToAction("Newpassword");
            }
            else
            {
                ModelState.AddModelError("", "Please Enter Correct Details");
            }
            return View();
        }
        public ActionResult Newpassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Newpassword(FormCollection form)
        {
            try
            {
                string newpass = form["Newpass"].ToString();
                string conpass = form["Conpass"].ToString();
                string adid = (string)Session["passrecovery"];
                if (newpass == conpass)
                {
                    var admin = con.Admins.Where(t => t.UserId == adid).FirstOrDefault();
                    admin.password = newpass;
                    con.SaveChanges();
                    return RedirectToAction("Passwordsuccess", "Admin");
                }
                else
                {
                    //ModelState.AddModelError("", "Newpassword and confirm password does not match");
                    Response.Write("<center><h2 style=" + "color:red" + ">Newpassword and confirm password does not match</h2></center>");
                    // return View();
                }

                return View();

            }
            catch
            {
                Response.Write("<center><h2 style=" + "color:red" + ">Password cannot be empty</h2></center>");
                return View();
            }
           
        }
        /*public ActionResult Newpassword(Admin admin)
        {
            var passdet = con.Admins.Where(n => n.Newpassword == n.Confirmpassword).FirstOrDefault();
            bool iscrct = con.Admins.Any(n => n.Newpassword == n.Confirmpassword);
            if (passdet != null)
            {
                var details = con.Admins.FirstOrDefault(c => c.UserId == admin.UserId);
                if (details != null)


                {
                    admin.password = passdet.Newpassword;
                    //details.password = admin.Newpassword;


                    con.SaveChanges();

                    return RedirectToAction("Passwordsuccess", "Admin");
                }
            }

            return View(admin);

        }*/
        public ActionResult Passwordsuccess()
        {
            return View();
        }
    }
}