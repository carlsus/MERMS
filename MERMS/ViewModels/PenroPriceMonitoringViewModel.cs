using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class PenroPriceMonitoringViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Tracking No.")]
        public string TrackingNo { get; set; }
        [Display(Name = "Date of Consolidated Report Released to PENRO")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReleasedPenro { get; set; }
        [Display(Name = "PENRO Report")]
        public IFormFile PenroReport { get; set; }
    }
}
