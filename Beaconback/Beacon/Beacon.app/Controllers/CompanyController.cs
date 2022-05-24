using Beacon.service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ISettingService _settingService;

        public CompanyController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public IActionResult Index()
        {
            return View(_settingService.GetSetting());
        }
    }
}
