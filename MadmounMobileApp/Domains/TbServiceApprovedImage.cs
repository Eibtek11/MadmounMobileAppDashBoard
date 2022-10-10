using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbServiceApprovedImage
    {
        public Guid ServiceApprovedImageId { get; set; }
        public string ImagePath { get; set; }
        public Guid? ServiceApprovedId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbServicesApproved ServiceApproved { get; set; }
    }
}
