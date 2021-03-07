using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Models
{
    public class PriceMonitoring
    {
        public int Id { get; set; }
        public DateTime? Month { get; set; }
        public string CenroConcerned { get; set; }
        public DateTime? ReleasedCenro { get; set; }
        public DateTime? ReceivedPenro { get; set; }
        public string CenroReport { get; set; }
        public string PenroReport { get; set; }
        public DateTime? DateOfSubmission { get; set; }
    }
}
