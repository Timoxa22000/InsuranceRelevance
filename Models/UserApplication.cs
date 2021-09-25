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
        [Display(Name = "БИК")]
        public string BIK { get; set; }
        [Display(Name = "Номер страховой лицензии")]
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
