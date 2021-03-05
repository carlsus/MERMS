using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Models
{
    public class MultiForestProtection
    {
        public int Id { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public string VenueOfMeeting { get; set; }
        public int NumberOfAttendees { get; set; }
        public string LetterOfInvitation { get; set; }
        public string AttendanceSheet { get; set; }
        public string MinutesOfMeeting { get; set; }
        public string PhotoDocumentation { get; set; }
    }
}
