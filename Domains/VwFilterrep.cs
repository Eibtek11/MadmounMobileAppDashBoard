using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwFilterrep
    {
        public Guid SrRepServiceId { get; set; }
        public Guid? ServiceId { get; set; }
        public string Id { get; set; }
        
        public Guid? CityId { get; set; }
      
        public Guid? AreaId { get; set; }


        public DateTime? CreatedDate { get; set; }


    }
}
