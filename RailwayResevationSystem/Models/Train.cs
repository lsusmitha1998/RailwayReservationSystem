using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string TrainName { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DateOfTravel { get; set; }
        [Required]
        public string TrainType { get; set; }
        [Required]
        public string CoachClass { get; set; }
        [Required]
        public string SeatAvailability { get; set; }
        [Required]
        public int NoOfSeat { get; set; }        

    }
}