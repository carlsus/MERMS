using MERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class PriceMonitoringReportModel
    {
        public IEnumerable<PriceMonitoring> PriceMonitorings { get; set; }
        public string Jurisdiction { get; set; }
        public int Year { get; set; }
    }
}
