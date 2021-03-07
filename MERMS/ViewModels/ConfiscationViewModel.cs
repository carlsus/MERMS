using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class ConfiscationViewModel
    {
        public int Id { get; set; }
        [Display(Name="Tracking Number")]
        public string TrackingNo { get; set; }
        [Display(Name = "CENRO Jurisdiction")]
        public string Jurisdiction { get; set; }
        [Display(Name = "Date Filed")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateFiled { get; set; }
        [Display(Name = "Docket/Case Number")]
        public string DocketCaseNo { get; set; }
        [Display(Name = "Case Title/Respondent")]
        public string CaseTitleRespondent { get; set; }
        [Display(Name = "Nature of Violation")]
        public string NatureOfViolation { get; set; }
        [Display(Name = "Court where Case Filed")]
        public string CourtFiled { get; set; }
        [Display(Name = "Plate Number of Vehicle")]

        public string VehiclePlateNo { get; set; }
        [Display(Name = "Kind/Species of Forest Product")]
        public string KindSpecies { get; set; }
        [Display(Name = "Estimated Value")]

        public double EstimatedValue { get; set; }
        [Display(Name = "Forest Product Stockpiled")]

        public string ForestProductStockPiled { get; set; }
        [Display(Name = "Board Feet")]
        public double BoardFeet { get; set; }
        [Display(Name = "Cubic Meter")]
        public double CubicMeter { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
