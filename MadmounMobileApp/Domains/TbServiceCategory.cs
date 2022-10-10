using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbServiceCategory
    {
        public TbServiceCategory()
        {
            TbServices = new HashSet<TbService>();
            TbSrOffServices = new HashSet<TbSrOffService>();
            TbSrRepServices = new HashSet<TbSrRepService>();
        }

        public Guid ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<TbService> TbServices { get; set; }
        public virtual ICollection<TbSrOffService> TbSrOffServices { get; set; }
        public virtual ICollection<TbSrRepService> TbSrRepServices { get; set; }
    }
}
