using Beacon.core.Models;
using Beacon.service.DTOs.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Sifre ve Parolu duzgun daxil edin");
                return View();
            }
               
            AppUser appUser = await _userManager.FindByNameAsync(loginDto.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Sifre ve Parolu duzgun daxil edin");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginDto.Password, true, true);

            if (!result.Succeeded)
            {
                    ModelState.AddModelError("", "duzgun username ve sifre daxil edin");
                    return View();   
            }

            return RedirectToAction("index", "setting");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
