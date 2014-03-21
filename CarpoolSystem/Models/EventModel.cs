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
        [Display(Name = "Starting Address")]
        public string StartingAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Starting City")]
        public string StartingCity { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Starting State")]
        public string StartingState { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Destination Address")]
        public string DestAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Destination City")]
        public string DestCity { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Destination State")]
        public string DestState { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string StartingTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public string EndingTime { get; set; }


        [StringLength(4000)]
        [Display(Name = "Event Infomation")]
        public string EventInfo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Days")]
        public string Days { get; set; }

        //Car Information
        [Required]
        [StringLength(50)]
        [Display(Name = "Make")]
        public string CarMake { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Year")]
        public Int32 CarYear { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Color")]
        public string CarColor { get; set; }

        [Required]
        [Display(Name = "Number of Seats")]
        public Int32 TotalSeats { get; set; }

       
    }

    public class EventSearchModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Starting Address")]
        public string StartingAddress { get; set; }

        [Display(Name = "Starting City")]
        public string StartingCity { get; set; }

        [Display(Name = "Starting State")]
        public string StartingState { get; set; }

        [Display(Name = "Destination Address")]
        public string EndingAddress { get; set; }

        [Display(Name = "Destination City")]
        public string DestCity { get; set; }

        [Display(Name = "Destination State")]
        public string DestState { get; set; }

        [Display(Name = "Start Time")]
        public string StartingTime { get; set; }

        [Display(Name = "End Time")]
        public string EndingTime { get; set; }

        [Display(Name = "Event Infomation")]
        public string EventInfo { get; set; }

        [Display(Name = "Days")]
        public string Days { get; set; }

        public IEnumerable<CarpoolSystem.Event> EventSearch { get; set; }

    }

}