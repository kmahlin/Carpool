using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarpoolSystem.Models
{
    public class EventModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Start Location")]
        public string StartingLocation { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Destination")]
        public string EndingLocation { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Event Infomation")]
        public int EventInfo { get; set; }

       
    }
}