using System;

namespace MadmounMobileApp.Models
{
    public class ServicesApproveViewPageModel
    {
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public string CreatedBy { get; set; }
       
        public string Notes { get; set; }


     

        public Guid? ServiceId { get; set; }

        public Guid? CityId { get; set; }

        public Guid? AreaId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
