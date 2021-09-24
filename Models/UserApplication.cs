using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models
{
    public class UserApplication : IdentityUser
    {
        public TypeUser TypeUser { get; set; }
        public string BIK { get; set; }
        public string LicenseNumber { get; set; }
    }

    public enum TypeUser
    {
        [Display(Name = "Банк")]
        Bank = 0,
        [Display(Name = "Страховая компания")]
        Insurance
    }
}
