using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbAdvertisements
    {
        public Guid AdvertisementId { get; set; }
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }

        public string AdvertisementImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

    }
}
