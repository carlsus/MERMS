using System;
using System.Collections.Generic;
using System.Text;
using MERMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MERMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApprehensionConfiscation> ApprehensionConfiscations { get; set; }
        public DbSet<Confiscation> Confiscation { get; set; }
        public DbSet<DonatedConfiscated> DonatedConfiscateds { get; set; }
        public DbSet<MultiForestProtection> MultiForestProtections { get; set; }
        public DbSet<PriceMonitoring> PriceMonitorings { get; set; }
        public DbSet<PenroPriceMonitoring> PenroPriceMonitorings { get; set; }
    }
}
