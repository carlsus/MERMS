using MERMS.Email;
using MERMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MERMS.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _usermanager { get; }
        private SignInManager<IdentityUser> _signinmanager { get; }

        public AccountController(UserManager<IdentityUser> usermanager,SignInManager<IdentityUser> signinmanager)
        {
            _signinmanager = signinmanager;
            _usermanager = usermanager;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> Logout()
        {

            await _signinmanager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

        [HttpGet]

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            User login = new User();
            login.ReturnUrl = returnUrl;
            return View(login);
        }
        public async Task<IActionResult> Login(User model)
        {
            var appUser = await _usermanager.FindByEmailAsync(model.Email);
            if (appUser != null)
            {
                await _signinmanager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _signinmanager.PasswordSignInAsync(appUser,model.Password, false, true);
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl ?? "/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed: Invalid Email or password");
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction("LoginTwoStep", new { appUser.Email,model.ReturnUrl });
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Failed: Invalid Email or password");

            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> LoginTwoStep(string email, string returnUrl)
        {
            var user = await _usermanager.FindByEmailAsync(email);

            var token = await _usermanager.GenerateTwoFactorTokenAsync(user, "Email");

            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmailTwoFactorCode(user.Email, token);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginTwoStep(TwoFactor twoFactor, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(twoFactor.TwoFactorCode);
            }

            var result = await _signinmanager.TwoFactorSignInAsync("Email",twoFactor.TwoFactorCode,true, twoFactor.RememberMachine);
            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/Home/Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View();
            }
        }
        //var result = await _signinmanager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);
        //if (result.Succeeded)
        //{
        //    return RedirectToAction("Index", "Home");
        //}
        //else
        //{
        //    ViewBag.Result = "These credentials do not match our records.";
        //}
        //return View();
    }


    
}
