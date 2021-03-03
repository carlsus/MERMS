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
        [Display(Name = "Date of Donation")]
        public DateTime DateOfDonation { get; set; }
        [Display(Name = "Donee/Recipient")]
        public string DoneeRecipient { get; set; }
        public string SpeciesForm { get; set; }
        public int NumberOfPieces { get; set; }
        public string VolumeBoardFeet { get; set; }
        public double EstimatedMarketValue { get; set; }
        public string Purpose { get; set; }

        public IFormFile FilePath { get; set; }
    }
}
