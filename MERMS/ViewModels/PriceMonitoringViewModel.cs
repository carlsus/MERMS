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
        [Display(Name = "Tracking No.")]
        public string TrackingNo { get; set; }
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
     
    }
}
