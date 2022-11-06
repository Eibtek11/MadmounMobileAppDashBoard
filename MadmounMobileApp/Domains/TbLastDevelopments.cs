using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial  class TbLastDevelopments
    {
        public Guid LastDevelopmentId { get; set; }
        public string LastDevelopmentName { get; set; }
        public string LastDevelopmentDescription { get; set; }

        public string LastDevelopmentImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
