using Beacon.core.Models;
using Beacon.service.DTOs;
using Beacon.service.DTOs.ServiceDtos;
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

    public class ServiceController : Controller
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
           GetListDto<ServiceGetDto> getListDto = await _service.GetAll();
            return View(getListDto);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServicePostDto postDto)
        {
            await _service.CreateAsync(postDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
           await _service.RemoveAync(id);
            return Json(new { status=200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            ServiceEditDto EditDTo = new ServiceEditDto();
            EditDTo.GetDto= await _service.Get(id);
            return View(EditDTo);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ServiceEditDto editDto)
        {
            ServiceEditDto EditDto = new ServiceEditDto();
            editDto.GetDto = await _service.Get(id);

            if (!ModelState.IsValid)
                return View(editDto);

            await _service.UpdateAsync(id, editDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
