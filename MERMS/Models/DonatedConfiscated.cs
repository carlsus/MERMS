using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Models
{
    public class DonatedConfiscated
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        public DateTime? DateOfDonation { get; set; }
        public string DoneeRecipient { get; set; }
        public string SpeciesForm { get; set; }
        public int NumberOfPieces { get; set; }
        public double VolumeBoardFeet { get; set; }
        public double EstimatedMarketValue { get; set; }
        public string Purpose { get; set; }
        public string FilePath { get; set; }
    }
}
