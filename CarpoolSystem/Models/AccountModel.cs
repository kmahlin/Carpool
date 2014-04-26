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
        [Display(Name = "Phone")]
        public Int64 Phone { get; set; }

        [Required]
        [Display(Name = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        public String image { get; set; }


    }
    public class LogInModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
    public class ChangePasswordModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Old password: ")]
        public string OldPassword { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "New password: ")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Confirm password: ")]
        public string ConfirmPassword { get; set; }
    }
    public class PasswordRetrievalModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Confirm Email: ")]
        public string ConfirmEmail { get; set; }
    }

    public class  EditProfileModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Emails { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public Int64 Phone { get; set; }

        public String image { get; set; }
    }

   
}