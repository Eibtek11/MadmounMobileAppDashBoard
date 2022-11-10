using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbServicesRequired
    {
        public TbServicesRequired()
        {

            TbServicesOfferss = new HashSet<TbServicesOffers>();

        }
        public Guid ServicesRequiredId { get; set; }
        public string ServiceSyntax { get; set; }
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }
        public string SrRequiredDescription { get; set; }

        //public int? CurrentState { get; set; }

        public virtual TbArea Area { get; set; }
        public virtual TbCity City { get; set; }
        public virtual TbService Service { get; set; }
        public virtual ICollection<TbServicesOffers> TbServicesOfferss { get; set; }
    }
}
