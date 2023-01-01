using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbCity
    {
        public TbCity()
        {
            TbAreas = new HashSet<TbArea>();
            TbChatSrOffSrReqs = new HashSet<TbChatSrOffSrReq>();
            TbChatSrRepSroffs = new HashSet<TbChatSrRepSroff>();
            TbServicesApproveds = new HashSet<TbServicesApproved>();
            //TbServicesRequireds = new HashSet<TbServicesRequired>();
            TbSrOffCities = new HashSet<TbSrOffCity>();
            TbSrRepCities = new HashSet<TbSrRepCity>();
        }

        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<TbArea> TbAreas { get; set; }
        public virtual ICollection<TbChatSrOffSrReq> TbChatSrOffSrReqs { get; set; }
        public virtual ICollection<TbChatSrRepSroff> TbChatSrRepSroffs { get; set; }
        public virtual ICollection<TbServicesApproved> TbServicesApproveds { get; set; }
        //public virtual ICollection<TbServicesRequired> TbServicesRequireds { get; set; }
        public virtual ICollection<TbSrOffCity> TbSrOffCities { get; set; }
        public virtual ICollection<TbSrRepCity> TbSrRepCities { get; set; }
    }
}
