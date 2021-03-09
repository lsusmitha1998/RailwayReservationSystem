using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayResevationSystem.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the User Id")]
        [MaxLength(8)]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter the First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter the Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter choose the Gender")]
        public string Gender { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter the Email ID")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public long ContactNumber { get; set; }
    }
}