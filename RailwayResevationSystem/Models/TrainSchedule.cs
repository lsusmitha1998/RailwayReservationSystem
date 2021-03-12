using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class TrainSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Train No")]
        public int TrainId { get; set; }
        [Display(Name = "Stations")]
        public string Stop { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
    }
}