using BL;
using BL.Models;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
        ServicesRequiredService servicesRequiredService;
        SrrepCityService srrepCityService;
        SroffCityService sroffCityService;
        ServiceApprovedMilstoneService serviceApprovedMilstoneService;
        IGetChat getChat;
        LogInHistoryService logInHistoryService;
        SrrepService srrepService;
        SrOffService srOffService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public HomeController(ServicesRequiredService ServicesRequiredService,SrrepCityService SrrepCityService,SroffCityService SroffCityService,ServiceApprovedMilstoneService ServiceApprovedMilstoneService,IGetChat GetChat,LogInHistoryService LogInHistoryService,UserManager<ApplicationUser> usermanager ,SrrepService SrrepService,SrOffService SrOffService,AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            srOffService = SrOffService;
            srrepService = SrrepService;
             Usermanager = usermanager;
            logInHistoryService = LogInHistoryService;
            getChat = GetChat;
            serviceApprovedMilstoneService = ServiceApprovedMilstoneService;
            sroffCityService = SroffCityService;
            srrepCityService = SrrepCityService;
            servicesRequiredService = ServicesRequiredService;
        }
        [Authorize(Roles = "Admin,Account,Administeration")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
           

            ViewBag.lstUsers = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").Count();
            ViewBag.lstSrRepService = Usermanager.Users.Where(a => a.StateName == "ممثل خدمة").Count();
            ViewBag.lstSrOffServiceS = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").Count();
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
            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            ViewBag.lstLogInHistoriesMonths = activeMonths.Count();
            model.lstAdvertisements = advertismentService.getAll();
           
            return View(model);
        }


        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment(string Id , string DateOne , string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrOffId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment2(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "ممثل خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrRepId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;

            return View(model);
        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment3(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne!=null && DateTwo!=null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrReqId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment4( string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if ( DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo));
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment5(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = serviceService.getAll();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.ServiceId == Guid.Parse(Id));
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }

        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment6(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            List<TbServicesRequired> lstServiceRequired = new List<TbServicesRequired>();
            lstServiceRequired = ctx.TbServicesRequireds.Include(a => a.Service).Where(a => a.CreatedDate >= DateTime.Parse("2020-11-05 22:17:26.510") && a.CreatedDate <= DateTime.Now).ToList();
            if (Id != null && DateOne != null && DateTwo != null)
            {
                lstServiceRequired = ctx.TbServicesRequireds.Include(a => a.Service).Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo)).Where(a => a.CreatedBy == Id).ToList();
            }
           
            var servicesNoRequested = (from t in lstServiceRequired
                                       group t by t.Service.ServiceName into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });
            ViewBag.cities = cityService.getAll();
            List<GetServicesNo> lstgetServicesNos = new List<GetServicesNo>();
            foreach (var i in servicesNoRequested)
            {
                GetServicesNo element = new GetServicesNo();
                element.ServiceName = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetServicesNo = lstgetServicesNos;
            
            return View(model);
        }

        [Authorize(Roles = "Admin,Account")]
        public IActionResult noOffByCity(string DateOne, string DateTwo)
        {
           
            HomePageModel model = new HomePageModel();
            model.lstUsers = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            if (DateOne != null && DateTwo != null)
            {
                model.lstUsers = model.lstUsers = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList().Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo));
            }
            var servicesNoRequested = (from t in model.lstUsers
                                       group t by t.CityName into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetNoOffByCity> lstgetServicesNos = new List<GetNoOffByCity>();
            foreach (var i in servicesNoRequested)
            {
                GetNoOffByCity element = new GetNoOffByCity();
                element.CityName = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetNoOffByCity = lstgetServicesNos;

            return View(model);
        }


        [Authorize(Roles = "Admin,Account")]
        public IActionResult noOffersByService()
        {
            HomePageModel model = new HomePageModel();
            var servicesNoRequested = (from t in ctx.TbServicesOfferss.ToList()
                                       group t by t.ServiceId into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetOffersNo> lstgetServicesNos = new List<GetOffersNo>();
            foreach (var i in servicesNoRequested)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetOffersNo = lstgetServicesNos;
            model.lstServices = serviceService.getAll();
            return View(model);
        }


        [Authorize(Roles = "Admin,Account")]
        public IActionResult collectiveReport(string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            List<TbServicesRequired> lstServiceRequired = new List<TbServicesRequired>();
            lstServiceRequired = ctx.TbServicesRequireds.Where(a => a.CreatedDate >= DateTime.Parse("2020-11-05 22:17:26.510") && a.CreatedDate <= DateTime.Now).ToList();
            if ( DateOne != null && DateTwo != null)
            {
                lstServiceRequired = ctx.TbServicesRequireds.Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo)).ToList();
            }
            var servicesNoRequired = (from t in lstServiceRequired.ToList()
                                       group t by t.ServicesRequiredId into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           s = myVar.FirstOrDefault().ServiceSyntax,
                                           d = myVar.FirstOrDefault().SrRequiredDescription,
                                           q = myVar.FirstOrDefault().SrReqId,
                                           dd= myVar.FirstOrDefault().CreatedDate
                                          
                                       });;
            var servicesNoOffersApproved = (from t in ctx.TbServicesOfferss.ToList().Where(a => a.Notes == "موافقة")
                                            group t by t.ServicesRequiredId into myVar
                                            select new
                                            {
                                                k = myVar.Key,
                                                c = myVar.Count()
                                            });
            var servicesNoOffersRejcted = (from t in ctx.TbServicesOfferss.ToList().Where(a => a.Notes == "مرفوضة")
                                            group t by t.ServicesRequiredId into myVar
                                            select new
                                            {
                                                k = myVar.Key,
                                                c = myVar.Count()
                                            });
            var servicesNoOffersWaiting = (from t in ctx.TbServicesOfferss.ToList().Where(a => a.Notes == "بانتظار الرد")
                                           group t by t.ServicesRequiredId into myVar
                                           select new
                                           {
                                               k = myVar.Key,
                                               c = myVar.Count()
                                           });
            var servicesNoOfferAll = (from t in ctx.TbServicesOfferss.ToList()
                                           group t by t.ServicesRequiredId into myVar
                                           select new
                                           {
                                               k = myVar.Key,
                                               c = myVar.Count()
                                           });
            List<GetOffersNo> lstservicesNoOffersAll = new List<GetOffersNo>();
            List<GetOffersNo> lstservicesNoOffersWaiting = new List<GetOffersNo>();
            List<GetOffersNo> lstservicesNoOffersRejected = new List<GetOffersNo>();
            List<GetOffersNo> lstservicesNoOffersApproved = new List<GetOffersNo>();
            foreach (var e in servicesNoOfferAll)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = e.k;
                element.count = e.c;
                lstservicesNoOffersAll.Add(element);

            }
            foreach (var e in servicesNoOffersWaiting)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = e.k;
                element.count = e.c;
                lstservicesNoOffersWaiting.Add(element);

            }
            foreach (var e in servicesNoOffersApproved)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = e.k;
                element.count = e.c;
                lstservicesNoOffersApproved.Add(element);

            }
            foreach (var e in servicesNoOffersRejcted)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = e.k;
                element.count = e.c;
                lstservicesNoOffersRejected.Add(element);

            }
            List<GetCollectiveReport> lstgetServicesNos = new List<GetCollectiveReport>();
            foreach (var i in servicesNoRequired)
            {
                GetCollectiveReport element = new GetCollectiveReport();
                element.ServicesRequiredId = i.k;
                element.ServiceSyntax = i.s;
                element.SrRequiredDescription = i.d;
                element.SrReqId = i.q;
                element.CreatedDate = i.dd;
                lstgetServicesNos.Add(element);

            }
            foreach(var i in lstgetServicesNos)
            {
                foreach(var el in lstservicesNoOffersApproved)
                {
                    if(el.ServiceId == i.ServicesRequiredId)
                    {
                        i.countOfOffersappoved = el.count;
                    }
                }
                foreach (var el in lstservicesNoOffersRejected)
                {
                    if (el.ServiceId == i.ServicesRequiredId)
                    {
                        i.countOfOffersRejected = el.count;
                    }
                }
                foreach (var el in lstservicesNoOffersWaiting)
                {
                    if (el.ServiceId == i.ServicesRequiredId)
                    {
                        i.countOfOffersWatiing = el.count;
                    }
                }
                foreach (var el in lstservicesNoOffersAll)
                {
                    if (el.ServiceId == i.ServicesRequiredId)
                    {
                        i.countOfOffers = el.count;
                    }
                }
            }
            model.LstGetCollectiveReport = lstgetServicesNos;
            model.lstServices = serviceService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);
        }























        [Authorize(Roles = "Admin,Account")]
        public IActionResult noOffersByServiceApproved()
        {
            HomePageModel model = new HomePageModel();
            var servicesNoRequested = (from t in ctx.TbServicesOfferss.ToList().Where(a=> a.Notes == "موافقة")
                                       group t by t.ServiceId into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetOffersNo> lstgetServicesNos = new List<GetOffersNo>();
            foreach (var i in servicesNoRequested)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetOffersNo = lstgetServicesNos;
            model.lstServices = serviceService.getAll();
            return View(model);
        }





        [Authorize(Roles = "Admin,Account")]
        public IActionResult noOffersByServiceRejected()
        {
            HomePageModel model = new HomePageModel();
            var servicesNoRequested = (from t in ctx.TbServicesOfferss.ToList().Where(a => a.Notes != "موافقة")
                                       group t by t.ServiceId into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetOffersNo> lstgetServicesNos = new List<GetOffersNo>();
            foreach (var i in servicesNoRequested)
            {
                GetOffersNo element = new GetOffersNo();
                element.ServiceId = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetOffersNo = lstgetServicesNos;
            model.lstServices = serviceService.getAll();
            return View(model);
        }


        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment7(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.LstVwFilterOffs = ctx.VwFilterOffs.Where(a => a.CreatedDate >= DateTime.Parse("2020-11-05 22:17:26.510") && a.CreatedDate <= DateTime.Now).ToList();
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstVwFilterOffs = ctx.VwFilterOffs.ToList().Where(a => a.ServiceId == Guid.Parse(Id)).Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo));
                
            }
           
            ViewBag.cities = serviceService.getAll();
           
            return View(model);
        }

        [Authorize(Roles = "Admin,Account")]
        public IActionResult Payment8(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepService = srrepService.getAll();
            model.LstVwFilterreps = ctx.VwFilterreps.Where(a => a.CreatedDate >= DateTime.Parse("2020-11-05 22:17:26.510") && a.CreatedDate <= DateTime.Now).ToList();
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstVwFilterreps = ctx.VwFilterreps.ToList().Where(a => a.ServiceId == Guid.Parse(Id)).Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo));
            }

            ViewBag.cities = serviceService.getAll();

            return View(model);
        }



        [Authorize(Roles = "Admin")]
        public IActionResult New(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            model.LstVwStages = ctx.VwStagess.ToList();
            if (Id != null)
            {
                model.LstVwStages = ctx.VwStagess.ToList().Where(a => a.ServicesRequiredId == Guid.Parse(Id));
            }

            ViewBag.cities = servicesRequiredService.getAll();
            int count = model.LstVwStages.Sum(a => int.Parse(a.PaidAmount));
            ViewBag.lstSrOffServiceS = count;

            int c = 0;
            foreach (var i in model.lstServiceApprovedMilstone)
            {
                c += int.Parse(i.CreatedBy);
            }
            int count2 = c;
            TbServicesApproved o = ctx.TbServicesApproveds.Where(a => a.CreatedBy == Id).FirstOrDefault();

            if (Id != null && o != null)
            {
                c = 0;
                foreach (var i in model.lstServiceApprovedMilstone.Where(a => a.ServiceApprovedId == o.ServiceApprovedId))
                {
                    c += int.Parse(i.CreatedBy);
                }
            }
            count2 = c;
            ViewBag.lstSrOffServiceS2 = count2;
            int count3 = count2 - count;
            ViewBag.lstSrOffServiceS3 = count3;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Payment9(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrOffCity = sroffCityService.getAll();
            if (Id != null)
            {
                model.lstSrOffCity = sroffCityService.getAll().Where(a => a.CityId == Guid.Parse(Id));
            }

            ViewBag.cities = cityService.getAll();

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Payment10(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            if (Id != null)
            {
                model.lstSrRepCity = srrepCityService.getAll().Where(a => a.CityId == Guid.Parse(Id));
            }

            ViewBag.cities = cityService.getAll();

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult stages(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            model.LstVwStages = ctx.VwStagess.ToList();
            if (Id != null)
            {
                model.LstVwStages = ctx.VwStagess.ToList().Where(a => a.ServicesRequiredId == Guid.Parse(Id));
            }

            ViewBag.cities = servicesRequiredService.getAll();
            int count = model.LstVwStages.Sum(a => int.Parse(a.PaidAmount));
            ViewBag.lstSrOffServiceS = count;
           
            int c = 0;
            foreach(var i in model.lstServiceApprovedMilstone)
            {
                c += int.Parse(i.CreatedBy);
            }
            int count2 = c;
            TbServicesApproved o = ctx.TbServicesApproveds.Where(a => a.CreatedBy ==Id).FirstOrDefault();

            if (Id != null && o !=null)
            {
                c = 0;
                foreach (var i in model.lstServiceApprovedMilstone.Where(a=> a.ServiceApprovedId == o.ServiceApprovedId))
                {
                    c += int.Parse(i.CreatedBy);
                }
            }
            count2 = c;
            ViewBag.lstSrOffServiceS2 = count2;
            int count3 = count2- count;
            ViewBag.lstSrOffServiceS3 = count3;
            return View(model);
        }


       


        
    }
}
