using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbService
    {
        public TbService()
        {
            TbChatSrOffSrReqs = new HashSet<TbChatSrOffSrReq>();
            TbChatSrRepSroffs = new HashSet<TbChatSrRepSroff>();
            TbServicesApproveds = new HashSet<TbServicesApproved>();
            TbServicesRequireds = new HashSet<TbServicesRequired>();
            TbSrOffServices = new HashSet<TbSrOffService>();
            TbSrRepServices = new HashSet<TbSrRepService>();
        }

        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public Guid? ServiceCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbServiceCategory ServiceCategory { get; set; }
        public virtual ICollection<TbChatSrOffSrReq> TbChatSrOffSrReqs { get; set; }
        public virtual ICollection<TbChatSrRepSroff> TbChatSrRepSroffs { get; set; }
        public virtual ICollection<TbServicesApproved> TbServicesApproveds { get; set; }
        public virtual ICollection<TbServicesRequired> TbServicesRequireds { get; set; }
        public virtual ICollection<TbSrOffService> TbSrOffServices { get; set; }
        public virtual ICollection<TbSrRepService> TbSrRepServices { get; set; }
    }
}
