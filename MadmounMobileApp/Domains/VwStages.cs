using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwStages
    {
        
        public Guid ServicesRequiredId { get; set; }
        public string ServiceSyntax { get; set; }
        
        public string CreatedBy { get; set; }


        public DateTime? CreatedDate { get; set; }

        public Guid ServiceId { get; set; }
        public string SrRequiredDescription { get; set; }

        public Guid TransactionId { get; set; }
        
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
       
        public Guid? CityId { get; set; }
       
        public Guid? AreaId { get; set; }
       
        public Guid ServiceApprovedMilstoneId { get; set; }
        public string ServiceApprovedMilstoneDesc { get; set; }
        public string PaidAmount { get; set; }
      
        public DateTime? PaidDate { get; set; }
        public string ProposedAmount { get; set; }
        public string ProjectPeriod { get; set; }
       
    }
}
