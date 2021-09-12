using LastChance.EmailServices;
using LastChance.Identity;
using LastChance.Model;
using LastChance.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;

        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {

            return View(new LoginModel()
            {

                ReturnUrl = ReturnUrl
            }); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu hesab tapilmadi yeniden yoxlayin");
                return View(model);
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {

                ModelState.AddModelError("", "Hesabinizi onaylayin");
                return View(model);

            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {

                return Redirect(model.ReturnUrl??"~/");
            }
           
            ModelState.AddModelError("", "Nese sehv var amma hele tutmamisam");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName = model.UserName,
                Email = model.Email

            };
            var result = await this._userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId=user.Id,
                    token=code
                });
                await _emailSender.SendEmailAsync(model.Email, "Hesabinizi Onaylayin", $"Tesdiqlemek ucun <a href='https://localhost:44388{url}'>buraya</a> basin");
                return RedirectToAction("Index", "Home");
            }
            var errors = result.Errors;
            var message = string.Join(", ", errors);
            ModelState.AddModelError("", message);
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Email tesdiqlenmedi", "danger");
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    CreateMessage("Hesabiniz Onaylandi", "success");
                    return View();
                }
            }
            CreateMessage("Hesab Onaylanmadi", "danger");
            return View();
        }
        public void CreateMessage(string messsage, string alerttype)
        {
            var message = new AlertData()
            {
                Message = messsage,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(message);
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            if (Email == null)
            {
                CreateMessage("Email bosdu", "danger");
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                CreateMessage("User Tapilmadi", "danger");
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(Email, "Sifre Resetlemek", $"Sifre resetlemek ucun  <a href='https://localhost:44388{url}'>buraya</a> basin");
            CreateMessage("Mail gonderildi", "success");
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userId,string token)
        {
            if (userId == null || token == null)
            {
                CreateMessage("Xeta bas verdi yeniden yoxlayin", "danger");
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel()
            {
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                CreateMessage("Istifadeci tapilmadi", "danger");
                return RedirectToAction("Index", "Home");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                CreateMessage("Password deyisdirildi","success");
                return RedirectToAction("Index", "Home");
                
            }
            CreateMessage("Xeta bas verdi yeniden yoxlayin", "danger");
            return View(model);
        }
    }
}
