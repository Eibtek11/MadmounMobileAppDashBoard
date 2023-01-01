using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Services
{
    public interface IEmailSenderr
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
