using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSrRepCity
    {
        public Guid SrRepCityId { get; set; }
        public Guid? CityId { get; set; }
        public string Id { get; set; }
        public Guid? AreaId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbArea Area { get; set; }
        public virtual TbCity City { get; set; }
    }
}
