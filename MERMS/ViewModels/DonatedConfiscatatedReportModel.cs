using MERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class DonatedConfiscatatedReportModel
    {

        public IEnumerable<DonatedConfiscated> DonatedConfiscateds { get; set; }
        public string Jurisdiction { get; set; }
        public int Year { get; set; }
    }
}
