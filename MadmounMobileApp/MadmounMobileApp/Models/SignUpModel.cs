using Microsoft.AspNetCore.Http;
using System;

namespace MadmounMobileApp.Models
{
    public class SignUpModel
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string UserName { get; set; }


        public IFormFile PersonalImage { get; set; }

        public string image { get; set; }

        public string Password { get; set; }

        public string CityName { get; set; }
        public string UpdatedBy { get; set; }

        public string Gender { get; set; }

        public string Notes { get; set; }

        public string StateName { get; set; }
        public string RyadahOrNot { get; set; }

        public string ServiceName { get; set; }

        public string PhoneNumber { get; set; }


        public string Services { get; set; }

        public Guid? ServiceId { get; set; }

        public Guid? CityId { get; set; }


    }
}
