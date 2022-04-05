using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Services;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Models
{
    public class AccountController : Controller
    {
        DataContext _context;
        UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<AppUser> _signInManager;
        IEmailService _emailService;
        IWebHostEnvironment _env;
        string checkToken = null;

        public AccountController(
            DataContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _env = env;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            

            AppUser user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user==null || user.isAdmin)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(loginVM);
            }

           
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser user = new AppUser()
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            };
            await _userManager.AddToRoleAsync(user, "Admin");
            TempData["Success"] = "Registration successful.";


            return RedirectToAction("login", "account");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByEmailAsync(forgotVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "User not found");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("resetpassword", "account", new { email = user.Email, token = token }, Request.Scheme);
            checkToken = token;

            var wrishUrl = Url.Action("index", "home");
            TempData["Success"] = "Link Send Your Email";

            var pathToFile = _env.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "Templates"
                + Path.DirectorySeparatorChar.ToString()
                + "EmailTemplate"
                + Path.DirectorySeparatorChar.ToString()
                + "ResetPassword.html";
            var builder = new BodyBuilder();
            using (StreamReader SoureReader=System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SoureReader.ReadToEnd();
            }

            string messageBody = string.Format(builder.HtmlBody, url, user.UserName);

            _emailService.Send(forgotVM.Email, "Reset Password", messageBody);

            return RedirectToAction("login", "account"); 
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user==null || !(await _userManager.VerifyUserTokenAsync(user,_userManager.Options.Tokens.PasswordResetTokenProvider,"ResetPassword",resetPasswordVM.Token)))
            {
                return RedirectToAction("login");
            }
            return View(resetPasswordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordViewModel resetPasswordVM)
        {
            if (string.IsNullOrWhiteSpace(resetPasswordVM.Password) || resetPasswordVM.Password.Length>25)
            {
                ModelState.AddModelError("Password", "Password is required and must be less than 26 character");
            }

            if (!ModelState.IsValid)
            {
                return View("ResetPassword", resetPasswordVM);
            }

            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);

            if (user==null)
            {
                return RedirectToAction("login");
            }
            
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ResetPassword", resetPasswordVM);
            }

            TempData["Success"] = "Your password has been successfully changed.";
            return RedirectToAction("login","account");
        }

        public async Task<IActionResult> Profile()
        {
            string UserCheck = User.Identity.Name;
            if (UserCheck == null)
            {
                return RedirectToAction("index", "home");
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);            
            ProfileViewModel profileVM = new ProfileViewModel
            {
                Member = new MemberUpdateViewModel
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    UserName = user.UserName
                },
                Orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x=>x.Product).Where(x => x.AppUserId == user.Id).ToList()
            };
            return View(profileVM);
        }



        //[Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> Profile(MemberUpdateViewModel memberVM)
        {
            AppUser member =await _userManager.FindByNameAsync(User.Identity.Name);
            ProfileViewModel profileVM = new ProfileViewModel
            {
                Member = memberVM,
                Orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).Where(x => x.AppUserId == member.Id).ToList()
            };
            if (!ModelState.IsValid)
            {
                return View(profileVM);
            }
            if (!await _userManager.CheckPasswordAsync(member,memberVM.CurrentPassword))
            {
                ModelState.AddModelError("CurrentPassword", "CurrentPassword is not correct");
                return View(profileVM);
            }

            if (member.Email !=memberVM.Email && _userManager.Users.Any(x=>x.NormalizedEmail == memberVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "This email has already been taken");
                return View(profileVM);
            }
            if (member.UserName != memberVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == memberVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "This username has already been taken");
                return View(profileVM);
            }
            member.Email = memberVM.Email;
            member.FullName = memberVM.FullName;
            member.UserName = memberVM.UserName;
            var result = await _userManager.UpdateAsync(member);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(profileVM);
            }


            if (!string.IsNullOrWhiteSpace(memberVM.Password) && !string.IsNullOrWhiteSpace(memberVM.RepeatPassword))
            {
                if (memberVM.Password!=memberVM.RepeatPassword)
                {
                    return View(profileVM);
                }
                var passwordResult = _userManager.ChangePasswordAsync(member, memberVM.CurrentPassword, memberVM.Password).Result;
                if (!passwordResult.Succeeded)
                {
                    foreach (var item in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(profileVM);
                }
            }
            _context.SaveChanges();
            await _signInManager.SignInAsync(member, true);
            TempData["Success"] = "Your account information has been updated.";
            return View(profileVM);
        }

        
        #region Add role
        //public async Task<IActionResult> AddRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    var result = await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    return Ok(result);
        //} 
        #endregion
    }
}
