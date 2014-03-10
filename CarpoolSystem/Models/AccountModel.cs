using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarpoolSystem.Models
{
    public class AccountModel
    {

        
        [Required]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public Int64 Phone { get; set; }

        [Required]
        [Display(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }


    }
}