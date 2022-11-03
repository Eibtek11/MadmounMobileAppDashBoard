
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message, string id);
        Task SendEmailAsync(Message message, string id , string user, string email);
        //Task SendEmailAsync2(Message message, string id, string user, TbRequest element);
        //Task SendEmailAsync3(Message message, string id, string user, TbRequest element);
        Task SendEmailAsyncToCustomerWithBookingDetails(Message message, Guid id);
        Task SendEmailAsyncToCustomer(Message message);

        Task SendEmailAsyncToCustomerNotConfirmedBooking(Message message, string Comment, string CustomerEmail);
    }
}
