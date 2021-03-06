﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MERMS.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string Position { get; set; }
        public string OfficeNo { get; set; }
        public string MobileNo { get; set; }
        public string PhotoPath { get; set; }
    }
}
