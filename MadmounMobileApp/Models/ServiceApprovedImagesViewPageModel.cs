using Microsoft.AspNetCore.Http;
using System;

namespace MadmounMobileApp.Models
{
    public class ServiceApprovedImagesViewPageModel
    {
        public IFormFile ImagePath { get; set; }

        public string CreatedBy { get; set; }
        public Guid? ServiceApprovedId { get; set; }
    }
}
