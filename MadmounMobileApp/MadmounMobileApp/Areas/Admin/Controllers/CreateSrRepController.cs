using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult IndexRayadah()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel , List<IFormFile> files)
        {
            oHomePageModel.lstAdvices = Ctx.TbAdvicess.ToList();
            try
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            oHomePageModel.image = ImageName;
                        }
                    }
                }
                else
                {
                    oHomePageModel.image = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

                }

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
                    FirstName = oHomePageModel.Email,
                    ServiceCategoryName = oHomePageModel.image,
                    Email = oHomePageModel.Email,
                    UserName = oHomePageModel.Email,
                    LastName = oHomePageModel.LastName,
                    state = 1,
                    StateName= "ممثل خدمة",
                    ServiceName = "pending"

            };
                var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                if (result.Succeeded)
                {



                    result.ToString();

                    ViewBag.id = user.Id;

                    return RedirectToAction("Index", "Home", new { area = "Admin" });
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



        public async Task<IActionResult> RegisterRayadah(HomePageModel oHomePageModel, List<IFormFile> files)
        {
            oHomePageModel.lstAdvices = Ctx.TbAdvicess.ToList();
            try
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            oHomePageModel.image = ImageName;
                        }
                    }
                }
                else
                {
                    oHomePageModel.image = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

                }

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
                    FirstName = oHomePageModel.Email,
                    ServiceCategoryName = oHomePageModel.image,
                    Email = oHomePageModel.Email,
                    UserName = oHomePageModel.Email,
                    LastName = oHomePageModel.LastName,
                    state = 1,
                    StateName = "ممثل خدمة",
                    ServiceName = "pending",
                    Services = "خدمات تمويلية"

                };
                var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                if (result.Succeeded)
                {



                    result.ToString();

                    ViewBag.id = user.Id;

                    return RedirectToAction("Index", "Home", new { area = "Admin" });
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
