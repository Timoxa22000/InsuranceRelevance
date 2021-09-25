using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models.Insurance
{
    public class InsuranceService
    {
        [Key]
        public Guid InsuranceServiceId { get; set; }
        [Display(Name = "Номер страхового контракта")]
        public string ServiceNumber { get; set; }
        [Display(Name = "Страховая сумма")]
        public decimal InsuranceSum { get; set; }
        [Display(Name = "Страховой тариф")]
        public decimal InsuranceRate { get; set; }
        [Display(Name = "Номер ипотечного договора")]
        public Guid ContractId { get; set; }
        public int CompanyInsuranceId { get; set; }
        public CompanyInsurance CompanyInsurance { get; set; }
        public InsuranceService ChangeCompanyInsurance(CompanyInsurance newCompany)
        {
            CompanyInsurance = newCompany;
            CompanyInsuranceId = newCompany.Id;
            return this;
        }
    }
    public enum StatusInsuranceService
    {
        Active = 0,
        Close
    }
}
