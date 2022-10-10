using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbServiceApprovedMilstone
    {
        public Guid ServiceApprovedMilstoneId { get; set; }
        public string ServiceApprovedMilstoneDesc { get; set; }
        public int? Cost { get; set; }
        public Guid? ServiceApprovedId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbServicesApproved ServiceApproved { get; set; }
    }
}
