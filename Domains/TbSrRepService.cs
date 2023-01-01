using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSrRepService
    {
        public Guid SrRepServiceId { get; set; }
        public Guid? ServiceId { get; set; }
        public string Id { get; set; }
        public Guid? ServiceCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbService Service { get; set; }
        public virtual TbServiceCategory ServiceCategory { get; set; }
    }
}
