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
    [Authorize(Roles = "Admin,Administeration")]
    public class AdvertismentController : Controller
    {
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public AdvertismentController(UserManager<ApplicationUser> usermanager, AdvertismentService AdvertismentService ,ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            ViewBag.cities = ctx.TbCities.ToList();
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstCities = cityService.getAll();
            return View(model);


        }
        public IActionResult Index2()
        {
            var markList = GetStudentMarkList();
            return View(markList);


        }




        public async Task<IActionResult> Save(TbAdvertisements ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.AdvertisementId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.AdvertisementImage = ImageName;
                    }
                }


                advertismentService.Add(ITEM);


            }
            else
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
                        ITEM.AdvertisementImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                advertismentService.Edit(ITEM);

            }

            ViewBag.cities = ctx.TbCities.ToList();
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstCities = cityService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbAdvertisements oldItem = ctx.Advertisementss.Where(a => a.AdvertisementId == id).FirstOrDefault();

            advertismentService.Delete(oldItem);
            ViewBag.cities = ctx.TbCities.ToList();
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstCities = cityService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbAdvertisements oldItem = ctx.Advertisementss.Where(a => a.AdvertisementId == id).FirstOrDefault();
            ViewBag.cities = ctx.TbCities.ToList();

            return View(oldItem);
        }


        //Make function in models and get data from database as per your requirement... //Dont do in controller like this
        public List<StudentMarkDetails> GetStudentMarkList()
        {
            HomePageModel model = new HomePageModel();


            ViewBag.lstUsers = Usermanager.Users.Where(a => a.state == 0).Count();
            ViewBag.lstSrRepService = Usermanager.Users.Where(a => a.state == 1).Count();
            ViewBag.lstSrOffServiceS = Usermanager.Users.Where(a => a.state == 2).Count();
            model.lstCities = cityService.getAll();
            ViewBag.lstCities = model.lstCities.Count();
            model.lstAreas = areaService.getAll();
            ViewBag.Areas = model.lstAreas.Count();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            ViewBag.lstServices = model.lstServices.Count();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            ViewBag.lstServicecATEGORIES = model.lstServicecATEGORIES.Count();
            var activeDays = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-1)).ToList()
                              group t by t.Id into myVar
                              select new
                              {
                                  k = myVar.Key,
                                  c = myVar.Count()
                              });

            ViewBag.lstLogInHistoriesDays = activeDays.Count();
            var activeWeeks = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-7)).ToList()
                               group t by t.Id into myVar
                               select new
                               {
                                   k = myVar.Key,
                                   c = myVar.Count()
                               });

            ViewBag.lstLogInHistoriesWeeks = activeWeeks.Count();
            var activeMonths = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-30)).ToList()
                                group t by t.Id into myVar
                                select new
                                {
                                    k = myVar.Key,
                                    c = myVar.Count()
                                });

            ViewBag.lstLogInHistoriesMonths = activeMonths.Count();
            model.lstAdvertisements = advertismentService.getAll();
            var studentmarkList = new List<StudentMarkDetails>()
            {
                new StudentMarkDetails() { id = 1, name = "John", Physics = ViewBag.lstUsers,Chemistry=ViewBag.lstSrRepService,Biology=ViewBag.lstSrOffServiceS},
                //new StudentMarkDetails() { id = 2, name = "Mary", Physics = 96,Chemistry=78,Biology=69,Mathematics=88 },
                //new StudentMarkDetails() { id = 3, name = "Asha", Physics = 49,Chemistry=85,Biology=63,Mathematics=77 },
                //new StudentMarkDetails() { id = 4, name = "Emily", Physics = 85,Chemistry=56,Biology=78,Mathematics=55 },
                //new StudentMarkDetails() { id = 5, name = "Bonnie", Physics = 74,Chemistry=55,Biology=36,Mathematics=69 },
            };
            return studentmarkList;
        }
        public List<StudentScoreDetails> GetStudentScoreDetails()
        {
            var studentscoreList = new List<StudentScoreDetails>()
            {
                new StudentScoreDetails() { id = 1, name = "John", score = 62},
                //new StudentScoreDetails() { id = 2, name = "Mary", score = 96 },
                //new StudentScoreDetails() { id = 3, name = "Asha", score = 49 },
                //new StudentScoreDetails() { id = 4, name = "Emily", score = 85 },
                //new StudentScoreDetails() { id = 5, name = "Bonnie", score = 74},
            };
            return studentscoreList;
        }
    }
}
