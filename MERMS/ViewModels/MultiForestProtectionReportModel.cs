using MERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class MultiForestProtectionReportModel
    {
        public IEnumerable<MultiForestProtection> MultiForestProtections { get; set; }
        public string Jurisdiction { get; set; }
        public int Year { get; set; }
    }
}
