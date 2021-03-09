using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class Payment
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public long CardNo { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public int Cvv { get; set; }
        [Required]
        public string CardType { get; set; }
        [Required]
        public double AvailableBalance { get; set; }
    }
}