using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwMillestone
    {
        public Guid ServiceApprovedMilstoneId { get; set; }
        public string ServiceApprovedMilstoneDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ServiceApprovedId { get; set; }
        public string MillestoneCost { get; set; }
        public string MillestoneDuration { get; set; }

        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public string createdServiceApproved { get; set; }
     
        public DateTime? contractDate { get; set; }
       
        public string ProjectDuration { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }
        public string cityname { get; set; }

        public Guid srrequiredid { get; set; }
     
        public string SrRequiredDescription { get; set; }

       


    }
}
