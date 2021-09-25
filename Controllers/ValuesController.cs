using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceRelevance.Models;
using InsuranceRelevance.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceRelevance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository _repository;
        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Получить инофрмацию о договоре
        /// </summary>
        /// <param name="numberContract"></param>
        /// <returns>Возвращает список извлеченных уроков</returns>
        /// <response code="201">Успешное выполнение запроса</response>
        [HttpGet("GetInfoBankContract")]
        [ProducesResponseType(typeof(BankContractViewModel), 201)]
        public async Task<BankContractViewModel> GetInfoBankContract([FromBody] string numberContract)
        {
            var units = await _repository.GetBankContractsViewModelFromNumber(numberContract);
            if (units == null)
            {
                units = new BankContractViewModel
                {
                    ContractNumber = numberContract
                };
            }
            return units;            
        }

        /// <summary>
        /// Получить остаток задолженности
        /// </summary>
        /// <param name="numberContract"></param>
        /// <returns>Возвращает список извлеченных уроков</returns>
        /// <response code="201">Успешное выполнение запроса</response>
        [HttpGet("GetAmouthBankContract")]
        [ProducesResponseType(typeof(string), 201)]
        public async Task<string> GetAmouthBankContract([FromBody] string numberContract)
        {
            var contract = await _repository.GetBankContractsFromNumber(numberContract);
            if (contract == null)
            {
                return $"Инофрмации по договору с номером {numberContract} не найдено";
            }
            return contract.ContractAmount.ToString();
        }
    }
}
