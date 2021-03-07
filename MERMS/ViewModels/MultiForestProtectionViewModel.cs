using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class MultiForestProtectionViewModel
    {

        public int Id { get; set; }
        [Display(Name="Tracking Number")]
        public string TrackingNo { get; set; }
        [Display(Name = "Date of Meeting")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfMeeting { get; set; }
        [Display(Name = "Venue of Meeting")]
        public string VenueOfMeeting { get; set; }
        [Display(Name = "Number of Attendees")]
        public int NumberOfAttendees { get; set; }
        public IFormFile LetterOfInvitation { get; set; }
        public IFormFile AttendanceSheet { get; set; }
        public IFormFile MinutesOfMeeting { get; set; }
        public IFormFile PhotoDocumentation { get; set; }
    }
}
