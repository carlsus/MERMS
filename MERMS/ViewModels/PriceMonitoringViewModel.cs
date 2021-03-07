using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class PriceMonitoringViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Month")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Month { get; set; }
        [Display(Name = "CENRO Concerned")]
        public string CenroConcerned { get; set; }
        [Display(Name = "Date of Report Released from CENRO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReleasedCenro { get; set; }
        [Display(Name = "Date of Report Received to PENRO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReceivedPenro { get; set; }
        [Display(Name = "CENRO Report")]
        public IFormFile CenroReport { get; set; }
        [Display(Name = "PENRO Report")]
        public IFormFile PenroReport { get; set; }
        [Display(Name = "Date of Submission of Consolidated Report Released at PENRO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfSubmission { get; set; }
    }
}
