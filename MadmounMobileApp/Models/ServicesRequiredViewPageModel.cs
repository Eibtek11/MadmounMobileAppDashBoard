using System;
using System.Collections.Generic;

namespace MadmounMobileApp.Models
{
    public class ServicesRequiredViewPageModel
    {
        public string ServiceSyntax { get; set; }

        //public string SrRepId { get; set; }

        public string SrReqId { get; set; }
        public List<Guid?>  ServiceId { get; set; }


        public string CreatedBy { get; set; }

        public string Notes { get; set; }
    }
}
