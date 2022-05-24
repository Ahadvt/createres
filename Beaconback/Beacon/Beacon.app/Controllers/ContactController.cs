using Beacon.app.ViewEntity;
using Beacon.service.DTOs.MessageDtos;
using Beacon.service.DTOs.SettingDtos;
using Beacon.service.Interfaces;
using Beacon.service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IMessageService _messageService;

        public ContactController(ISettingService settingService,IMessageService messageService)
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

        [HttpPost]
        public async Task<IActionResult> SenMessage(MessagePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return Json("Make sure you fill in the fields correctly");
            }

           await _messageService.Create(postDto);

            return Json(new { status=200});
        }
    }
}
