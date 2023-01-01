using BL;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Administeration")]
    public class SrReqController : Controller
    {
        AreaService areaService;
        ServiceCategoryService serviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        MadmounDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        RoleManager<IdentityRole> RoleManager;

        public SrReqController(AreaService AreaService, ServiceCategoryService ServiceCategoryService, ServiceService ServiceService, CityService CityService, RoleManager<IdentityRole> roleManager, MadmounDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListReqsAsync(Guid? id, string DateOne, string DateTwo)
        {
           

            HomePageModel model = new HomePageModel();
            model.lstUsers = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList();
            if (DateOne != null && DateTwo != null)
            {
                model.lstUsers = model.lstUsers = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList().Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo));
            }

            return View(model);
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
               
                ServiceCategoryName = user.ServiceCategoryName,
                AreaName = user.AreaName,
                Gender = user.Gender,
                RyadahOrNot = user.RyadahOrNot,
                BirthDate = user.BirthDate,
               
              
               
                StateName = user.StateName,
                state = user.state,
              
                Claims = userClaims.Select(a => a.Value).ToList(),
                Roles = userRoles

            };




            return View(model);
        }




        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await Usermanager.FindByIdAsync(id.ToString());
            var result = await Usermanager.DeleteAsync(user);
            if (result.Succeeded)
            {







                return Redirect("ListReqsAsync");
            }




            return Redirect("ListReqsAsync");



        }
    }
}
