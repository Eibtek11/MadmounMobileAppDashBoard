﻿using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CreateSrRepController : Controller
    {
        SrrepService srrepService;
        LogInHistoryService lgHistory;
        MadmounDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;

        public CreateSrRepController(SrrepService SrrepService,LogInHistoryService LgHistory, MadmounDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            lgHistory = LgHistory;
            srrepService = SrrepService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel)
        {
            oHomePageModel.lstAdvices = Ctx.TbAdvicess.ToList();
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
                    LastName = oHomePageModel.LastName

                };
                var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                if (result.Succeeded)
                {



                    result.ToString();

                    ViewBag.id = user.Id;
                    return View(oHomePageModel);
                }
                else
                {

                    return View("Index", oHomePageModel);
                }

            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }






        }
    }
}