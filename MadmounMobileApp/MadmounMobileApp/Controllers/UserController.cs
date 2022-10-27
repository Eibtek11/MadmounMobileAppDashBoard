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

namespace MadmounMobileApp.Controllers
{
    public class UserController : Controller
    {
        LogInHistoryService lgHistory;
        MadmounDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;

        public UserController(LogInHistoryService LgHistory,MadmounDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            lgHistory = LgHistory;

        }


        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                //    var user = new ApplicationUser()
                //    {
                //        Email = oHomePageModel.Email,
                //        UserName = oHomePageModel.Email

                //    };
                //    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                //    if (result.Succeeded)
                //    {





                //        result.ToString();

                //        return Redirect("~/");
                //    }
                //    else
                //    {
                //        var error = result.Errors.ToList();
                //        string erresult = "";
                //        string erresult2 = "";
                //        foreach (var er in error)
                //        {
                //            erresult = string.Format("{0}\t\t{1}", erresult, er.Description);



                //        }

                //        this.ModelState.AddModelError("Password", erresult);
                //        this.ModelState.AddModelError("Email", erresult2);
                //        return View("LogIn", oHomePageModel);
                //    }
                //}
                //else
                //{
                //    return View("LogIn", oHomePageModel);
                //}


                var user = new ApplicationUser()
                {
                    Email = oHomePageModel.Email,
                    UserName = oHomePageModel.Email,
                    LastName = oHomePageModel.LastName,
                    state = oHomePageModel.state


                };
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

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {

                    string id = Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().Id;
                    TbLoginHistory item = new TbLoginHistory();
                    item.Id = id;
                    item.CreatedDate = DateTime.Now;
                    item.LogInId = new Guid();

                    lgHistory.Add(item);


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
    }
}
