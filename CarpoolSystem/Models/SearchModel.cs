using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarpoolSystem.Models
{
    public class SearchModel
    {
        [Display(Name = "Starting City")]
        public string StartingCity { get; set; }


        [Display(Name = "Starting State")]
        public string StartingState { get; set; }
    }
}