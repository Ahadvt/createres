using Beacon.service.DTOs.SettingDtos;
using Beacon.service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Areas.Manage.Controllers
{
    [Area("Manage")]

    [Authorize(Roles = "Admin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
            
        }
        public IActionResult Index()
        {   
            return View(_settingService.GetSetting());
        }
        public IActionResult Update()
        {
            SettingPostDto settingPostDto = new SettingPostDto();
            settingPostDto.GetDto = _settingService.GetSetting();
            return View(settingPostDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,SettingPostDto postDto)
        {
            SettingPostDto settingPostDto = new SettingPostDto();
            settingPostDto.GetDto = _settingService.GetSetting();


            if (!ModelState.IsValid)
                return View(settingPostDto);

            await _settingService.UpdateAsync(id, postDto);

            return RedirectToAction(nameof(Index));
        }

    }
}
