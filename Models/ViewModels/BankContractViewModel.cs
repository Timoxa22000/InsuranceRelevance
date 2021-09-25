using InsuranceRelevance.Models.Bank;
using InsuranceRelevance.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models.ViewModels
{
    public class BankContractViewModel
    {
        public Contract BankContract { get; set; }
        public List<InsuranceServiceUnit> InsurancesService { get; set; }
        public BankContractViewModel()
        {
            InsurancesService = new List<InsuranceServiceUnit>();
        }        
    }
    public class InsuranceServiceUnit
    {
        public InsuranceService InsuranceService { get; set; }
        public List<LifeCycleInsuranceService> LifeCycleInsuranceServices { get; set; }
        public InsuranceServiceUnit(List<LifeCycleInsuranceService> lifeCycleInsuranceServices, InsuranceService insuranceService)
        {
            LifeCycleInsuranceServices = lifeCycleInsuranceServices;
            InsuranceService = insuranceService;
        }
    }
}
