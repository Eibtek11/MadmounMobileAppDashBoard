using System;
using System.Net;

namespace MadmounMobileApp.Models
{
    public class ResponseStatusInfoModel
    {
        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
