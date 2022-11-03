using Microsoft.AspNetCore.Http;

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


    }
}
