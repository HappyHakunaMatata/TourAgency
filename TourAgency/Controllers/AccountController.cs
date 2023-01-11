using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourAgency.Data;
using TourAgency.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TourAgency.Services.Interfaces;
using TourAgency.Services.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Google.Apis.PeopleService.v1.Data;
using Microsoft.AspNetCore.Http;

namespace TourAgency.Controllers
{
	public class AccountController:Controller
	{
		private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _IHttpContextAccessor;



        public AccountController(AppDbContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> UserManager, IEmailSender emailSender, IHttpContextAccessor IHttpContextAccessor)
		{
			_context = context;
            _signInManager = signInManager;
            _UserManager = UserManager;
            _emailSender = emailSender;
            _IHttpContextAccessor = IHttpContextAccessor;
        }


        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterRequest request)
		{
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = request.Email,
                    Email = request.Email
                };
                var result = await _UserManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Main");
                }
                //ModelState.AddModelError("", "Username or password is incorrect");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
			return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            UserLoginRequest model = new UserLoginRequest
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest request, string? returnUrl)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
                await AddClaims(request.Email);


                if (result.Succeeded)
                {
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Main");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Username or password incorrect");
            return View(request);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            UserLoginRequest loginViewModel = new UserLoginRequest
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                Console.WriteLine($"Error from external provider: { remoteError}");
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            // Get the login information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                Console.WriteLine("Error loading external login information.");
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", loginViewModel);
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                //var email = info.Principal.Claims.FirstOrDefault(m => m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
                HttpContext.Session.SetString("Name", info.Principal.Claims.FirstOrDefault(m => m.Type == "urn:google:name").Value);
                HttpContext.Session.SetString("Photo", info.Principal.Claims.FirstOrDefault(m => m.Type == "urn:google:picture").Value);

                /*var user = await _UserManager.FindByEmailAsync(email);
                var claims = new List<Claim>(){
                    info.Principal.Claims.FirstOrDefault(m => m.Type == "urn:google:name"),
                    info.Principal.Claims.FirstOrDefault(m => m.Type == "urn:google:picture"),
                    new Claim("Provider",info.Principal.Claims.FirstOrDefault().Issuer)
                };
                await _UserManager.AddClaimsAsync(user,claims);*/

                Console.WriteLine("Succeeded");
                return LocalRedirect(returnUrl);
            }
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account
            else
            {
                // Get the email claim value
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    Console.WriteLine("NotNullEmail");
                    // Create a new user without password if we do not have a user already
                    var user = await _UserManager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new IdentityUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        await _UserManager.CreateAsync(user);
                    }
                    Console.WriteLine("NullEmail");
                    // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                    await _UserManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                // If we cannot find the user email we cannot continue
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";
                return View("Error");
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("Photo");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Main");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(UserForgotRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
                else
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
                    var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
                    await _emailSender.SendEmailAsync(message);
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }
            }
            return View();
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new UserResetRequest { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(UserResetRequest resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await _UserManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await _UserManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }


        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult Complete(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        private async Task AddClaims(string email)
        {
            List<Claim> claims = new List<Claim>()
            {
            new Claim("IPV4Address", _IHttpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()),
            new Claim("IPV6Address", _IHttpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString()),
            new Claim("LocalIPV4Address", _IHttpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString()),
            };
            var user = await _UserManager.FindByEmailAsync(email);
            await _UserManager.AddClaimsAsync(user, claims);
        }
    }
}
