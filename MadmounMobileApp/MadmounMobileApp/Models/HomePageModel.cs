using BL;
using BL.Models;
using Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Models
{
    public class HomePageModel
    {
        public IEnumerable<ApplicationUser> UserData { get; set; }


        public UserModel user { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        public bool RememberMe { get; set; }


        public string LastName { get; set; }
        public string ReturnUrl { get; set; }


        public ApplicationUser OneUser { get; set; }

        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        
        public string FirstName { get; set; }
      
        public string CityName { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }


        public Guid? ServiceCategoryId { get; set; }


        public Guid? ServiceId { get; set; }


        public string ServiceName { get; set; }

        public string ServiceCategoryName { get; set; }



        public string AreaName { get; set; }

        public string Gender { get; set; }

        public string RyadahOrNot { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Services { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }


        public string DocumentA { get; set; }


        public string DocumentB { get; set; }


        public string DocumentC { get; set; }


        public string DocumentD { get; set; }

        public int? SerialDocumentA { get; set; }


        public int? SerialDocumentB { get; set; }


        public int? SerialDocumentC { get; set; }


        public int? SerialDocumentD { get; set; }

        public string StateName { get; set; }


        public int? state { get; set; }


        public string Cateegory { get; set; }


        public int? category { get; set; }

        public string image { get; set; }

        public IFormFile PersonalPhoto { get; set; }

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }



        public IEnumerable<TbCity> lstCities { get; set; }
        public IEnumerable<TbArea> lstAreas { get; set; }
        public IEnumerable<TbService> lstServices { get; set; }

        public IEnumerable<TbServiceCategory> lstServicecATEGORIES { get; set; }

        public IEnumerable<TbComplain> lstComplains { get; set; }

        public IEnumerable<TbLoginHistory> lstLogInHistories { get; set; }

        public IEnumerable<TbServicesRequired> lstServicesRequireds { get; set; }

        public IEnumerable<TbServicesApproved> lstServicesApprovedS { get; set; }

        public IEnumerable<TbServiceApprovedImage> lstServiceApprovedImageS { get; set; }

        public IEnumerable<TbServiceApprovedMilstone> lstServiceApprovedMilstone { get; set; }
        public IEnumerable<TbSrOffService> lstSrOffServiceS { get; set; }

        public IEnumerable<TbSrRepService> lstSrRepService { get; set; }

        public IEnumerable<ApplicationUser> lstUsers{ get; set; }

        public IEnumerable<TbSrRepCity> lstSrRepCity { get; set; }

        public IEnumerable<TbSrOffCity> lstSrOffCity { get; set; }

        public IEnumerable<TbClients> lstClients { get; set; }

        public IEnumerable<TbClientImages> lstClientImages { get; set; }


        public IEnumerable<TbAdvertisements> lstAdvertisements { get; set; }


        public IEnumerable<TbAdvices> lstAdvices { get; set; }

        public IEnumerable<TbServicesOffers> LstServicesOffers { get; set; }
        public IEnumerable<TbLastDevelopments> LstLastDevelopments { get; set; }

        public IEnumerable<TbTransaction> LstTransactionS { get; set; }

        public IEnumerable<TbServicesFinished> LstTbServicesFinished { get; set; }

        public IEnumerable<GetPayment> LstGetPayment { get; set; }

        public IEnumerable<GetServicesNo> LstGetServicesNo { get; set; }

        public IEnumerable<GetServicesApproed> LstGetServicesApproed { get; set; }


        public IEnumerable<VwFilterOff> LstVwFilterOffs { get; set; }




        public IEnumerable<VwFilterrep> LstVwFilterreps { get; set; }


        public IEnumerable<VwStages> LstVwStages { get; set; }

    }
}
