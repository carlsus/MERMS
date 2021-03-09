using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Models
{
    public class PenroPriceMonitoring
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        public DateTime? ReleasedPenro { get; set; }
        public string PenroReport { get; set; }
    }
}
