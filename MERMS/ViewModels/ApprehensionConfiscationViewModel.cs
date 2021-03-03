using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class ApprehensionConfiscationViewModel
    {
        public int Id { get; set; }
        public string Jurisdiction { get; set; }
        public string PlaceOfApprehension { get; set; }
        public DateTime? DateOfConfiscation { get; set; }
        public int NumberOfPieces { get; set; }
        public string Species { get; set; }
        public string BoardFeet { get; set; }
        public string CubicMeter { get; set; }
        public string VehiclePlateNo { get; set; }
        public string ParaphernaliaSerialNo { get; set; }
        public string Offender { get; set; }
        public string Address { get; set; }
        public string Custodian { get; set; }
        public string Status { get; set; }
        public double EstimatedValue { get; set; }
        public string Remarks { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
