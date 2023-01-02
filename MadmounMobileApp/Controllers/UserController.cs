using BL;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MadmounMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Authorization;
using MadmounMobileApp.Services;
using MadmounMobileApp.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmailService;
using Microsoft.AspNetCore.Http;
using Twilio.TwiML.Messaging;
using Microsoft.IdentityModel.Tokens;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using System.Text.Encodings.Web;

namespace MadmounMobileApp.Controllers
{
    public class UserController : Controller
    {
        LogInHistoryService lgHistory;
        MadmounDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;
        IUserValidator<ApplicationUser> v;
        SignInManager<ApplicationUser> SignInManager;
        private readonly ISMSService _smsService;
        IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly UrlEncoder _urlEncoder;
       
        public UserController(RoleManager<IdentityRole> roleManager,UrlEncoder urlEncoder, IUserValidator<ApplicationUser> V,ISmsSender smsSender, IEmailSender emailSender, ISMSService smsService,LogInHistoryService LgHistory,MadmounDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            lgHistory = LgHistory;
            _smsService = smsService;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _urlEncoder = urlEncoder;
            v = V;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {

            return View();
        }
        public IActionResult SendCode(SendCodeViewModel model)
        {
            var user =  SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            //var userFactors =  Usermanager.GetValidTwoFactorProvidersAsync(user);
            //var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();

            return View();
        }
        [HttpGet]
        public IActionResult LoginWith2fa()
        {

            return View();
        }
       


        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                //create roles
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));

            }
            try
            {

               

                var user = new ApplicationUser()
                {
                    Email = oHomePageModel.Email,
                    UserName = oHomePageModel.Email,
                    LastName = oHomePageModel.LastName,
                    state = oHomePageModel.state,
                    StateName = oHomePageModel.StateName,
                    TwoFactorEnabled = true,
                    CreatedDate = DateTime.Now

                };
                if (user.StateName == "ممثل خدمة")
                {
                    user.ServiceName = "pending";
                    user.state = 1;
                }
                var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                if (result.Succeeded)
                {





                    result.ToString();

                    return Redirect("~/");
                }
                else
                {

                    return View("LogIn", oHomePageModel);
                }

            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }






        }
        [HttpPost]
        public async Task<IActionResult> LogInn(HomePageModel oHomePageModel)
        {
            try
            {
              

               
             
                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
               

                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {

                    if (Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().state == 2)
                    {
                        string id = Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().Id;
                        TbLoginHistory item = new TbLoginHistory();
                        item.Id = id;
                        item.CreatedDate = DateTime.Now;
                        item.UpdatedBy = Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().Email;
                        item.LogInId = new Guid();
                        item.CreatedBy = Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().CityName;
                        lgHistory.Add(item);

                    }
                 


                    // i hased 15 line
                    //SendSMSDto dto = new SendSMSDto();
                    //dto.MobileNumber = Usermanager.Users.Where(a => a.Id == id).FirstOrDefault().PhoneNumber;
                    //var user  = await Usermanager.FindByEmailAsync(oHomePageModel.Email);
                    //var code = await Usermanager.GenerateTwoFactorTokenAsync(user, "Phone");
                    //var UserWithCode = Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
                    //UserWithCode.AreaName = code;
                    //var addCode = await Usermanager.UpdateAsync(UserWithCode);
                    //if (string.IsNullOrWhiteSpace(code))
                    //{
                    //return View("Error");
                    //}

                    //var message = "Your security code is: " + code;
                    //dto.Body = message;


                    //var resultt = _smsService.Send(dto.MobileNumber, dto.Body);



                    //return RedirectToAction(nameof(VerifyCode), new { ReturnUrl = oHomePageModel.ReturnUrl, Id = id });
                    return Redirect(oHomePageModel.ReturnUrl);

                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(VerifyAuthenticatorCode), new { oHomePageModel.ReturnUrl, oHomePageModel.RememberMe });
                }

                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }




        public async Task<IActionResult> SignIn(HomePageModel oHomePageModel)
        {
            try
            {


                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {



                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();


            return Redirect("~/");

        }
        public IActionResult LogIn(string ReturnUrl)
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();

                oHomePageModel.user = new UserModel()
                {
                    ReturnUrl = ReturnUrl
                };


                return View(oHomePageModel);

            }
            catch (Exception ex)
            {

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }





        }
        public IActionResult AccessDenied()
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();

                return View(oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }


        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };
            return View(resetPasswordModel);
        }
        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await Usermanager.ResetPasswordAsync(await Usermanager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await Usermanager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendCode(SendCodeViewModel model,IFormFileCollection files)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await Usermanager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            var message = "Your security code is: " + code;
            if (model.SelectedProvider == "Email")
            {
                //var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);
                //await _emailSender.SendEmaillAsync(messages,await Usermanager.GetEmailAsync(user), "Security Code", message);
            }
            else if (model.SelectedProvider == "Phone")
            {
                await _smsSender.SendSmsAsync(await Usermanager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction(nameof(VerifyCode), new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string Id , string ReturnUrl)
        {
           
            // Require that the user has already logged in via username/password or external login
           
           
            return View(new VerifyCodeViewModel { ReturnUrl = ReturnUrl , Provider = Id });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            var UserWithCode = Usermanager.Users.Where(a => a.Id == model.Provider).FirstOrDefault();

            if (UserWithCode.AreaName == model.Code)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return View("LogIn");
            }
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }




        [HttpGet]
        public async Task<IActionResult> EnableAuthenticator()
        {
            string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

            var user = await Usermanager.GetUserAsync(User);
            await Usermanager.ResetAuthenticatorKeyAsync(user);
            var token = await Usermanager.GetAuthenticatorKeyAsync(user);
            //var code = await Usermanager.GenerateTwoFactorTokenAsync(user, "Phone");
          
            //SendSMSDto dto = new SendSMSDto();
            
            //var message = "Your security code is: " + code;
            //dto.Body = message;
            //dto.MobileNumber = Usermanager.Users.Where(a => a.Email == user.Email).FirstOrDefault().PhoneNumber;

            //var resultt = _smsService.Send(dto.MobileNumber, dto.Body);
            string AuthenticatorUri = string.Format(AuthenticatorUriFormat, _urlEncoder.Encode("MadmounMobileApp"),
                _urlEncoder.Encode(user.Email), token);
            var model = new TwoFactorAuthenticationViewModel() { Token = token, QRCodeUrl = AuthenticatorUri };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EnableAuthenticator(TwoFactorAuthenticationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await Usermanager.GetUserAsync(User);
                var succeeded = await Usermanager.VerifyTwoFactorTokenAsync(user, Usermanager.Options.Tokens.AuthenticatorTokenProvider, model.Code);
                if (succeeded)
                {
                    await Usermanager.SetTwoFactorEnabledAsync(user, true);
                }
                else
                {
                    ModelState.AddModelError("Verify", "Your two factor auth code could not be avalidated.");
                    return View(model);
                }

            }
            return RedirectToAction(nameof(AuthenticatorConfirmation));
        }

        [HttpGet]
        public IActionResult AuthenticatorConfirmation()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyAuthenticatorCode(bool rememberMe, string returnUrl = null)
        {
            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(new VerifyAuthenticatorViewModel { ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyAuthenticatorCode(VerifyAuthenticatorViewModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.TwoFactorAuthenticatorSignInAsync(model.Code, model.RememberMe, rememberClient: false);
        
            if (result.Succeeded)
            {
                return LocalRedirect(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Code.");
                return View(model);
            }

        }





        [HttpPost]
        public IActionResult LockUnlock(string userId)
        {

            ApplicationUser objFromDb = Usermanager.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (objFromDb == null)
            {
                return NotFound();
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is locked and will remain locked untill lockoutend time
                //clicking on this action will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
                TempData[SD.Success] = "User unlocked successfully.";
            }
            else
            {
                //user is not locked, and we want to lock the user
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
                TempData[SD.Success] = "User locked successfully.";
            }
            Ctx.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Indexx()
        {
            var userList = Ctx.Users.ToList();
            var userRole = Ctx.UserRoles.ToList();
            var roles = Ctx.Roles.ToList();
            foreach (var user in userList)
            {
                var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if (role == null)
                {
                    user.Role = "None";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }
            }
            return View();

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string userId)
        {
            ViewBag.cities = _roleManager.Roles.ToList();
            var objFromDb = Ctx.Users.FirstOrDefault(u => u.Id == userId);
            if (objFromDb == null)
            {
                return NotFound();
            }
            var userRole = Ctx.UserRoles.ToList();
            var roles = Ctx.Roles.ToList();
            var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);
            if (role != null)
            {
                objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
            }
            objFromDb.RoleList = new List<System.Web.Mvc.SelectListItem>();
            objFromDb.RoleList2 = new List<System.Web.Mvc.SelectListItem>();
            objFromDb.RoleList3 = new List<string>();
            var userRole2 = Ctx.UserRoles.Where(u => u.UserId == objFromDb.Id).ToList();
            objFromDb.RoleListMain = _roleManager.Roles.ToList();
            foreach (var i in userRole2)
            {

                System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                a.Value = i.RoleId;
                a.Selected = true;
                a.Text = Ctx.Roles.Where(u => u.Id == i.RoleId).FirstOrDefault().Name;
                objFromDb.RoleList.Add(a);


            }

            foreach (var l in objFromDb.RoleListMain)
            {
                if (!objFromDb.RoleList.Any(a => a.Value == l.Id))
                {
                    System.Web.Mvc.SelectListItem a = new System.Web.Mvc.SelectListItem();
                    a.Value = l.Id;
                    a.Selected = false;
                    a.Text = Ctx.Roles.Where(u => u.Id == l.Id).FirstOrDefault().Name;
                    objFromDb.RoleList.Add(a);
                    objFromDb.RoleList3.Add(a.Text);
                }
            }






            return View(objFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            ViewBag.cities = _roleManager.Roles.ToList();


            List<string> previousRoleName = new List<string>();
            foreach (var i in user.RoleList)
            {
                previousRoleName.Add(Ctx.Roles.Where(u => u.Id == i.Value).FirstOrDefault().Name);
            }
            //removing the old role
            await Usermanager.RemoveFromRolesAsync(user, previousRoleName);
            Ctx.SaveChanges();
            List<string> newRoleName = new List<string>();
            foreach (var i in user.RoleList.Where(c => c.Selected))
            {
                newRoleName.Add(Ctx.Roles.Where(u => u.Id == i.Value).FirstOrDefault().Name);
            }


            //add new role
            await Usermanager.AddToRolesAsync(user, newRoleName);

            Ctx.SaveChanges();
            TempData[SD.Success] = "User has been edited successfully.";
            return RedirectToAction("Indexx", "User", new { area = "" });



            return View(user);
        }


    }
}
