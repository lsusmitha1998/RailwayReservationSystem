using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double Price { get; set; }
        [Display(Name = "Date Of Booking")]
        [Column(TypeName = "DateTime2")]
        public DateTime DateOfBooking { get; set; }
        public long CardNo { get; set; }
        public string ConfirmationStatus { get; set; }

    }
}