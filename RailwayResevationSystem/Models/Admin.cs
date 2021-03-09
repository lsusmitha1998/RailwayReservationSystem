using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RailwayResevationSystem.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Enter UserId")]
        public string UserId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }
    }
}