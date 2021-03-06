using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class ApprehensionConfiscationViewModel
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        [Required]
        [Display(Name ="CENRO Jurisdiction")]
        public string Jurisdiction { get; set; }
        [Display(Name = "Place of Apprehension")]
        public string PlaceOfApprehension { get; set; }
        [Display(Name = "Date of Confiscaton")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfConfiscation { get; set; }
        [Display(Name = "Number of Pieces")]
        public string Species { get; set; }
        [Display(Name = "Board Feet")]
        public string BoardFeet { get; set; }
        [Display(Name = "Cubic Meter")]
        public string CubicMeter { get; set; }
        [Display(Name = "Vehicle and Plate Number")]
        public string VehiclePlateNo { get; set; }
        [Display(Name = "Paraphernalia and Serial Number")]
        public string ParaphernaliaSerialNo { get; set; }
        public string Offender { get; set; }
        public string Address { get; set; }
        public string Custodian { get; set; }
        public string Status { get; set; }
        [Display(Name = "Estimated Value")]
        public string EstimatedValue { get; set; }
        public string Remarks { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
