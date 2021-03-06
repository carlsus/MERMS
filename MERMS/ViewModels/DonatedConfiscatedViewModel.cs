using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.ViewModels
{
    public class DonatedConfiscatedViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tracking Number")]
        public string TrackingNo { get; set; }
        [Display(Name = "Date of Donation")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfDonation { get; set; }
        [Display(Name = "Donee/Recipient")]
        public string DoneeRecipient { get; set; }
        [Display(Name = "Species/Form")]
        public string SpeciesForm { get; set; }
        [Display(Name = "Number of Pieces")]
        public int NumberOfPieces { get; set; }
        [Display(Name = "Volume (board feet)")]
        public string VolumeBoardFeet { get; set; }
        [Display(Name = "Estimated Market Value")]
        public string EstimatedMarketValue { get; set; }
        public string Purpose { get; set; }

        public IFormFile FilePath { get; set; }
    }
}
