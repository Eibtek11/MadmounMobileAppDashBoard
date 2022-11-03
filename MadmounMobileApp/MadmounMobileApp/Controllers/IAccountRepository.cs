using BL;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadmounMobileApp.Controllers
{
    public interface IAccountRepository
    {

       
        Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel);
        Task<ApplicationUser> LLoginAsync(SignInModel signInModel);

        Task<ApplicationUser> EditUsers(EditUserViewModell editModel);
        Task<ApplicationUser> EditUsersImage(EditUserViewModell editModel);

        Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user, IFormFileCollection files);
        Task SendForgotPasswordEmail(ApplicationUser user, string token, IFormFileCollection files);
        Task<ApplicationUser> ExternalLoginCallbackApi(string provider, string key, string returnUrl = null, string remoteError = null);
    }
}
