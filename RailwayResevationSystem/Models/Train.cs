using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class Train
    {
        [Key]
        public int Id { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TrainId { get; set; }
        [Required]
        [Display(Name ="Train Name")]
        public string TrainName { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [Display(Name = "Date Of Travel")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTravel { get; set; }
        [Required]
        [Display(Name = "Arrival Time")]
        public string TimeOfArrival { get; set; }
        [Required]
        [Display(Name = "Train Type")]
        public string TrainType { get; set; }
        
        [Required]
        [Display(Name ="Availability")]
        public string SeatAvailability { get; set; }
        [Required]
        [Display(Name = "No Of Seats")]
        public int NoOfSeat { get; set; }
    }
}