using InsuranceRelevance.Models;
using InsuranceRelevance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceRelevance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserApplication> _userManager;
        private readonly IRepository _repository;
        public HomeController(ILogger<HomeController> logger, UserManager<UserApplication> userManager, IRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _repository = repository;
        }

        //Определяем тип пользователя и перебрасываем на его страницу
        public async Task<IActionResult> Index()
        {
            var userAppliation = await _userManager.GetUserAsync(HttpContext.User);
            if (userAppliation.TypeUser == TypeUser.Bank)
            {
                return RedirectToAction(nameof(Bank));
            }
            else
            {
                return RedirectToAction(nameof(Ins));
            }
        }

        public IActionResult Bank()
        {
            return View();
        }

        public IActionResult Ins()
        {
            return View();
        }

        public async Task<IActionResult> LoadBankContractInfo(string numberContract)
        {
            //Специально для этого представление создан объект BankContractViewModel  который и возвращается из базы
            var units = await _repository.GetBankContractsViewModelFromNumber(numberContract);
            if (units == null)
            {
                units = new BankContractViewModel
                {
                    ContractNumber = numberContract
                };
            }
            
            return View(units);
        }

        public async Task<string> InsuranceInfo(string numberContract)
        {
            var contract = await _repository.GetBankContractsFromNumber(numberContract);
            if (contract == null)
            {
                return $"Инофрмации по договору с номером {numberContract} не найдено";
            }
            return contract.ContractAmount.ToString();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
