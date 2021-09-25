using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Models.Bank
{
    public class Contract
    {
        [Key]
        public Guid ContarctId { get; set; }
        [Display(Name = "Номер контракта")]
        public string NumberContract { get; set; }
        [Display(Name = "Дата создания в системе")]
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;
        [Display(Name = "Дата заключения контракта")]
        public DateTimeOffset? StartDate { get; set; }
        [Display(Name = "Дата завершения контракта")]
        public DateTimeOffset? CompleteDate { get; set; }
        [Display(Name = "Плановая дата завершения контракта")]
        public DateTimeOffset? CompletePlanDate { get; set; }
        [Display(Name = "Сумма контракта")]
        public decimal? ContractAmount { get; set; }
        public int CompanyBankId { get; set; }
        public CompanyBank CompanyBank { get; set; }
    }

    public enum StatusContract
    {
        [Display(Name = "Предварительный")]
        Preliminary = 0,
        [Display(Name = "Одобренный")]
        Approved,
        [Display(Name = "Заключенный контракт")]
        Signed,
        [Display(Name = "Завершенный контракт")]
        Completed
    }
}
