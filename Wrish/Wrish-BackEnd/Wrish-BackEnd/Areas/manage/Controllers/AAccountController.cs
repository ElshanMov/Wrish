using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Areas.manage.ViewModels;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]

    public class AAccountController : Controller
    {
        DataContext _context;
        UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<AppUser> _signInManager;

        public AAccountController(DataContext context, 
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user==null)
            {
                ModelState.AddModelError("", "User Name or Password incorrect");
                return View();
            }

            var result = _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "User Name or Password incorrect");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("login","aaccount");
        }

        #region CreateUser
        //public async Task<IActionResult> CreateUser()
        //{

        //    AppUser appUser = new AppUser
        //    {
        //        FullName = "Elshan Mammadov",
        //        UserName = "SuperAdmin",
        //        Email = "tu201906137@code.edu.az",
        //        isAdmin = true
        //    };

        //    var result = await _userManager.CreateAsync(appUser, "Wrish.P201");

        //    AppUser user = await _userManager.FindByNameAsync("SuperAdmin");

        //    await _userManager.AddToRoleAsync(user, "SuperAdmin");
        //    return Ok();
        //} 
        #endregion
    }
}
