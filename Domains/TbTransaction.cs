using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbTransaction
    {
        public Guid TransactionId { get; set; }
        public Guid ServicesRequiredId { get; set; }
        public Guid ServicesOffersId { get; set; }
        public Guid ServiceApprovedId { get; set; }
        public string ServiceSyntax { get; set; }
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public Guid? ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public Guid? CityId { get; set; }
        public string CityName { get; set; }
        public Guid? AreaId { get; set; }
        public string AreaName { get; set; }
        public Guid ServiceApprovedMilstoneId { get; set; }
        public string ServiceApprovedMilstoneDesc { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public string ContractPdf { get; set; }
        public string SrApprovedDescription { get; set; }
       
       
       
      
       
    }
}
