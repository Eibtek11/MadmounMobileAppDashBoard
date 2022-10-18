using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbAdvices
    {
        public Guid AdvicetId { get; set; }
        public string AdviceName { get; set; }
        public string AdviceDescription { get; set; }

        public string AdvertisementImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
