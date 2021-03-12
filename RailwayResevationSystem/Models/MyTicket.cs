using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class MyTicket
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TrainId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        [Display(Name = "No of Tickets")]
        public int NoofTickets { get; set; }
        public int Price { get; set; }
        [Display(Name = "Date Of Booking")]
        public DateTime DateOfBooking { get; set; }

    }
}