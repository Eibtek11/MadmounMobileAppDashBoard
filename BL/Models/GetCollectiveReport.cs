using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class GetCollectiveReport
    {
        public Guid? ServicesRequiredId { get; set; }
        public string ServiceSyntax { get; set; }
        public string SrRequiredDescription { get; set; }
        public int countOfOffers { get; set; }
      
        public int countOfOffersappoved { get; set; }

        public int countOfOffersRejected { get; set; }


        public int countOfOffersWatiing { get; set; }


        public string SrReqId { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
