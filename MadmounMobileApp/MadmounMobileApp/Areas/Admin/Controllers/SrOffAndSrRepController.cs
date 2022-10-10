using BL;
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
    public class SrOffAndSrRepController : Controller
    {
        AreaService areaService;
        ServiceCategoryService serviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        MadmounDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        RoleManager<IdentityRole> RoleManager;

        public SrOffAndSrRepController(AreaService AreaService,ServiceCategoryService ServiceCategoryService,ServiceService ServiceService,CityService CityService,RoleManager<IdentityRole> roleManager,MadmounDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            RoleManager = roleManager;
            cityService = CityService;
            serviceService = ServiceService;
            serviceCategoryService = ServiceCategoryService;
            areaService = AreaService;
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = Usermanager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUsers(string id)
        {
            ViewBag.Cities = cityService.getAll();
            ViewBag.Services = serviceService.getAll();
            ViewBag.ServiceCategories = serviceCategoryService.getAll();
            ViewBag.Areas = areaService.getAll();
            var user = await Usermanager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.errormessage = $"user with id = {id} cannot be found";
                return View("notfound");
            }
                var userClaims = await Usermanager.GetClaimsAsync(user);
                var userRoles = await Usermanager.GetRolesAsync(user);

                var model = new EditUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CityName = user.CityName,
                    CityId = user.CityId,
                    AreaId = user.AreaId,
                    ServiceCategoryId = user.ServiceCategoryId,
                    ServiceId = user.ServiceId,
                    ServiceName = user.ServiceName,
                    ServiceCategoryName = user.ServiceCategoryName,
                    AreaName = user.AreaName,
                    Gender = user.Gender,
                    RyadahOrNot = user.RyadahOrNot,
                    BirthDate = user.BirthDate,
                    Services = user.Services,
                    DocumentA = user.DocumentA,
                    DocumentB = user.DocumentB,
                    DocumentC = user.DocumentC,
                    DocumentD = user.DocumentD,
                    SerialDocumentA = user.SerialDocumentA,
                    SerialDocumentB = user.SerialDocumentB,
                    SerialDocumentC = user.SerialDocumentC,
                    SerialDocumentD = user.SerialDocumentD,
                    StateName = user.StateName,
                    state = user.state,
                    Cateegory = user.Cateegory,
                    category = user.category,
                    PersonalPhoto = user.PersonalPhoto,
                    Claims = userClaims.Select(a => a.Value).ToList(),
                    Roles = userRoles

                };

               

           
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> EditUsers(EditUserViewModel model)
        {
            ViewBag.Cities = cityService.getAll();
            ViewBag.Services = serviceService.getAll();
            ViewBag.ServiceCategories = serviceCategoryService.getAll();
            ViewBag.Areas = areaService.getAll();
            var user = await Usermanager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.errormessage = $"user with id = {model.Id} cannot be found";
                return View("notfound");
            }
            else
            {
                user.Id = model.Id;
                user.Email = model.Email;
                    user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.CityName = model.CityName;
                user.CityId = model.CityId;
                user.AreaId = model.AreaId;
                user.ServiceCategoryId = model.ServiceCategoryId;
                user.ServiceId = model.ServiceId;
                user.ServiceName = model.ServiceName;
                user.ServiceCategoryName = model.ServiceCategoryName;
                user.AreaName = model.AreaName;
                user.Gender = model.Gender;
                user.RyadahOrNot = model.RyadahOrNot;
                user.BirthDate = model.BirthDate;
                user.Services = model.Services;
                user.DocumentA = model.DocumentA;
                user.DocumentB = model.DocumentB;
                user.DocumentC = model.DocumentC;
                user.DocumentD = model.DocumentD;
                user.SerialDocumentA = model.SerialDocumentA;
                user.SerialDocumentB = model.SerialDocumentB;
                user.SerialDocumentC = model.SerialDocumentC;
                user.SerialDocumentD = model.SerialDocumentD;
                user.StateName = model.StateName;
                user.state = model.state;
                user.Cateegory = model.Cateegory;
                user.category = model.category;
                user.PersonalPhoto = model.PersonalPhoto;
              
                var result = await Usermanager.UpdateAsync(user);
                if (result.Succeeded)
                {





                   

                    return Redirect("ListUsers");
                }

                return View(model);
            }
           




           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
