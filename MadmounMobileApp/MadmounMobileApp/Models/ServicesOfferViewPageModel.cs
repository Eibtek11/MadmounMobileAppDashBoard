using System;

namespace MadmounMobileApp.Models
{
    public class ServicesOfferViewPageModel
    {
        public string OfferSyntax { get; set; }
        public string ServiceOfferCost { get; set; }
        public string ServiceOfferDuration { get; set; }
        public Guid? ServicesRequiredId { get; set; }
        public string SrRepId { get; set; }
        public string SrReqId { get; set; }
        public string SrOffId { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
