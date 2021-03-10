using RailwayResevationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayResevationSystem.Controllers
{
    public class TrainUserController : Controller
    {
        // GET: TrainUser
        ReservationContext con = new ReservationContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FindTrain()
        {
            Train train = new Train();
            return View(train);
        }
        [HttpPost]
        public ActionResult FindTrain(Train train)
        {
            //var trainlist = from i in con.Trains where i.Source == train.Source && i.Destination == train.Destination && Convert(date,i.DateOfTravel) == train.DateOfTravel select i;
            var trains = con.Trains.Where(t => t.Source == train.Source && t.Destination == train.Destination && t.DateOfTravel == train.DateOfTravel).ToList();
            return View("FindTrainList", trains);
        }
        public ActionResult Trainschedule(int? id)
        {

            var schedule = con.TrainSchedules.Where(t => t.TrainId == id).ToList();
            return View(schedule);
        }
    }
}