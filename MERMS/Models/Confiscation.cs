using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Models
{
    public class Confiscation
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        public string Jurisdiction { get; set; }
        public DateTime? DateFiled { get; set; }
        public string DocketCaseNo { get; set; }
        public string CaseTitleRespondent { get; set; }
        public string NatureOfViolation { get; set; }
        public string CourtFiled { get; set; }
        public string VehiclePlateNo { get; set; }
        public string KindSpecies { get; set; }
       
        public double EstimatedValue { get; set; }
        public string ForestProductStockPiled { get; set; }
        public double BoardFeet { get; set; }
        public double CubicMeter { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string FilePath { get; set; }
    }
}
