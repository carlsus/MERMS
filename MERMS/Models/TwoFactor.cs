using System;
using System.ComponentModel.DataAnnotations;

namespace MERMS.Models
{
    public class TwoFactor
    {
        [Required]
        public string TwoFactorCode { get; set; }
        [Display(Name = "Remember this machine")]
        public bool RememberMachine { get; set; }
    }
}
