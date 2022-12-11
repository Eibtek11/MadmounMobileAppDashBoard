using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class GetServicesOffers
    {
        public Guid ServicesOffersId { get; set; }
        public string OfferSyntax { get; set; }
        public string ServiceOfferCost { get; set; }
        public string ServiceOfferDuration { get; set; }
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }
        public Guid? ServicesRequiredId { get; set; }
    }
}
