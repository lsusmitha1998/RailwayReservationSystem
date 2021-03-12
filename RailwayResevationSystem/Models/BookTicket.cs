using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class BookTicket
    {
        [Key]
        //[Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public string Coach { get; set; }
        [Required]
        [Display(Name ="Seat Location")]
        public string SeatLocation { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name ="No Of Seats")]
        public int NoOfTickets { get; set; }
    }
}