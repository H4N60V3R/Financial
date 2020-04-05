using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Common;
using Financial.Models.Entities;
using Financial.Models.Enums;
using Financial.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    TempData["ToasterState"] = ToasterState.Info;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.LoginSuccessful;

                    return RedirectToAction("Index", "Home");
                }

                TempData["ToasterState"] = ToasterState.Error;
                TempData["ToasterType"] = ToasterType.Message;
                TempData["ToasterMessage"] = Messages.LoginFailed;

                return RedirectToAction("Login");
            }

            return BadRequest();
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser
        //        {
        //            UserName = model.Username,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            NationalCode = model.NationalCode,
        //            Address = model.Address
        //        };

        //        var result = await userManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            await signInManager.SignInAsync(user, false);
        //            return RedirectToAction("Index", "Home");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    //foreach (var error in result.Errors)
                    //{
                    //    ModelState.AddModelError(string.Empty, error.Description);
                    //}

                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.ChangePasswordFailed;

                    return RedirectToAction("Index", "Home");
                }

                await signInManager.SignOutAsync();

                TempData["ToasterState"] = ToasterState.Success;
                TempData["ToasterType"] = ToasterType.Message;
                TempData["ToasterMessage"] = Messages.ChangePasswordSuccessful;

                return RedirectToAction("Login");
            }

            return BadRequest();
        }
    }
}