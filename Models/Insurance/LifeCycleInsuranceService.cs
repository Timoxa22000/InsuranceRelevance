using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models.Insurance
{
    public class LifeCycleInsuranceService
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset DateTime { get; set; } = DateTimeOffset.Now;
        public string Subject { get; set; }
        public Guid InsuranceServiceId { get; set; }
        public InsuranceService InsuranceService { get; set; }
        public LifeCycleInsuranceService(string subject)
        {
            Subject = subject;
        }
    }
}
