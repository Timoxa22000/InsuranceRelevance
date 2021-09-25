using InsuranceRelevance.Models;
using InsuranceRelevance.Models.Bank;
using InsuranceRelevance.Models.Insurance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceRelevance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserApplication> UsersApplication { get; set; }
        public DbSet<CompanyBank> CompanyBanks { get; set; }
        public DbSet<Contract> ContractsBanks { get; set; }
        public DbSet<CompanyInsurance> CompanyInsurances { get; set; }
        public DbSet<InsuranceService> InsuranceServices { get; set; }
        public DbSet<LifeCycleInsuranceService> LifeCyclesIS { get; set; }
    }
}
