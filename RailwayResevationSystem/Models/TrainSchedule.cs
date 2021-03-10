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
        public int TrainId { get; set; }
        public string Stop { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }
    }
}