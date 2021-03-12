using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayResevationSystem.Models;
namespace RailwayResevationSystem.Controllers
{
    public class BookTicketController : Controller
    {
        // GET: BookTicket

        ReservationContext con = new ReservationContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrainId(int trainid)
        {
            Session["Traindid"] = trainid;
            //Session["uid"] = userid;
            return RedirectToAction("TicketBook");
        }
       [HttpGet]
        public ActionResult TicketBook()
        {
            //var booktic = new BookTicket();
            return View();
        }
        [HttpPost]
        public ActionResult TicketBook(FormCollection form)
        {
            /*ViewBag.coach= form["Coachvalue"].ToString();
            ViewBag.trainid = (int)Session["Traindid"];
            ViewBag.user= (string)Session["User"];
            ViewBag.tickets = Convert.ToInt32(form["nooftickets"].ToString());*/
            var book = new BookTicket();
            book.Coach = form["Coachvalue"].ToString();
            book.SeatLocation = form["SeatLocation"].ToString();
            book.NoOfTickets = Convert.ToInt32(form["nooftickets"].ToString());           
            book.TrainId = (int)Session["Traindid"];
            book.UserId = (string)Session["User"];
            int tickets = Convert.ToInt32(form["nooftickets"].ToString());
            double price = 0;
            string coach = form["Coachvalue"].ToString();
            if (coach == "1 Tier AC")
            {
               price = (tickets * 900);
            }
            else if (coach == "2 Tier AC")
            {
                price = (tickets * 700);
            }
            else if (coach == "Sleeper class")
            {
                book.Price = (tickets * 400);
            }
            else
            {
                price = (tickets * 100);
            }
            book.Price = price;
            //con.BookTickets.Add(book);
            //con.SaveChanges();
            Session["Price"] = price;
            TempData["booking"] = book;
            TempData.Keep();
            return RedirectToAction("Create", "Payments");
            
                 
           // return View("TicketBookcheck");
            
        }
        public ActionResult OnBook()
        {
            return View();
        }


        
       /* public ActionResult CancelBooking(int trainid,string userid)
        {
            var deletedbook = con.MyBookings.Where(t => t.TrainId == trainid && t.UserId == userid).FirstOrDefault();
            con.MyBookings.Remove(deletedbook);
            con.SaveChanges();
            var price = from i in con.BookTickets where i.TrainId == trainid && i.UserId == userid select i.Price;
           // var pa
            return View();
        }*/
    }
}
/*public ActionResult Book(int trainid)
{
    Session["booktid"] = trainid;
    return RedirectToAction("Booking");
}
[HttpGet]
public ActionResult Booking()
{
    BookTicket b = new BookTicket();
    return View(b);
}

public ActionResult BookingTicket(BookTicket book)
{
    //BookTicket book = new BookTicket();
    /*book.Coach = Coach;
    book.SeatLocation = Seatloc;
    book.NoOfTickets = noofseats;
    if (book.Coach == "1 Tier AC")
    {
        book.Price = (book.NoOfTickets * 900);
    }
    else if (book.Coach == "2 Tier AC")
    {
        book.Price = (book.NoOfTickets * 700);
    }
    else if (book.Coach == "Sleeper")
    {
        book.Price = (book.NoOfTickets * 400);
    }
    else
    {
        book.Price = (book.NoOfTickets * 100);
    }
    book.TrainId = (int)Session["booktid"];
    book.UserId = (string)Session["User"];
    if (ModelState.IsValid)
    {
        con.BookTickets.Add(book);
        con.SaveChanges();
        //return View();
        return RedirectToAction("Index");
    }
    return View(book);
}

/*[HttpPost]
public ActionResult Booking(BookTicket book)
{
    if (ModelState.IsValid)
    {
        book.TrainId = (int)Session["booktid"];
    //var train = con.Trains.Where(t=>)
    book.UserId = (string)Session["User"];
    int tickets = book.NoOfTickets;
    if(book.Coach== "1 Tier AC")
    {
        book.Price = (tickets * 900);
    }
    else if (book.Coach == "2 Tier AC")
    {
        book.Price = (tickets * 700);
    }
    else if (book.Coach == "Sleeper")
    {
        book.Price = (tickets * 400);
    }
    else
    {
        book.Price = (tickets * 100);
    }
    con.BookTickets.Add(book);
        con.SaveChanges();
        //return View();
        return RedirectToAction("Index");
    }

    return View(book);

}*/