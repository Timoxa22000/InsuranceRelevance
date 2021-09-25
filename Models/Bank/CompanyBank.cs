using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models.Bank
{
    public class CompanyBank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
