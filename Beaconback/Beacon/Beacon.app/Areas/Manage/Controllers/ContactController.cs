using Beacon.service.DTOs;
using Beacon.service.DTOs.MessageDtos;
using Beacon.service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
        {
           return View(await _messageService.GetALl());
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _messageService.Remove(id);
            return Json(new { status = 200 });
        }
    }
}
