using InsuranceRelevance.Models;
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
        public HomeController(ILogger<HomeController> logger, UserManager<UserApplication> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
