using Beacon.app.ViewEntity;
using Beacon.service.Interfaces;
using Beacon.service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IMessageService _messageService;

        public HomeController(ISettingService settingService, IMessageService messageService)
        {
            _settingService = settingService;
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
        {
            HomeEntity HomeEntity = new HomeEntity
            {
                SettingGetDto = _settingService.GetSetting()
            };
            return View(HomeEntity);
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }



    }
}
