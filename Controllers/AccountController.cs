using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using newmvccore.Models;

namespace newmvccore.Controllers
{

    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinmanager)
        {
            UserManager = userManager;
            Signinmanager = signinmanager;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> Signinmanager { get; }

        [HttpGet]
        public IActionResult Index()
        {
            return View("register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginviewModel loginviewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await Signinmanager.PasswordSignInAsync(loginviewModel.email, loginviewModel.password,
                                                                     isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }

                }
                ModelState.AddModelError(string.Empty, "login attempt failed");
            }
            return View(loginviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    city=model.city
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await Signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("register", model);
        }

        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await Signinmanager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsemailUsed(string email)
        {
            var user= await UserManager.FindByEmailAsync(email);
            if (user==null)
            {
                return Json(true);
            }
            else
            {
                return Json($"The provided {email} is already in use");
            }
        }
    }
}