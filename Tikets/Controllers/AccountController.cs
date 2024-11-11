using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Tikets.Models;
using Tikets.Utility;
using Tikets.ViewModels;

namespace Tikets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManger ,SignInManager<ApplicationUser> signInManager ,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
            if (_roleManager.Roles.IsNullOrEmpty())
            {
                await _roleManager.CreateAsync(new(StaticData.Admin));
                await _roleManager.CreateAsync(new(StaticData.User));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Address = userVM.Address
                };
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,StaticData.User);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    TempData["logedIn"] = "Loged in successfully";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Password It must consist of at least 6 letters, lowercase and uppercase");
            }
            return View(userVM);
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM userVM)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.FindByNameAsync(userVM.UserName);
                if (applicationUser != null && await _userManager.CheckPasswordAsync(applicationUser, userVM.Password))
                {
                    await _signInManager.SignInAsync(applicationUser, userVM.RememberMe);
                    TempData["logedIn"] = "Loged in successfully";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Invalid Username Or Password");
            }
            return View(userVM);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn" , "Account");
        }
        [Authorize(Roles =$"{StaticData.Admin}")]
        public IActionResult CreateNewAdmin()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{StaticData.Admin}")]
        public async Task< IActionResult > CreateNewAdmin(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    Address = userVM.Address
                };
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, StaticData.Admin);
                    TempData["CreatedAdmin"] = "User Created";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Password It must consist of at least 6 letters, lowercase and uppercase");
            }
            return View(userVM);
        }
    }
}
