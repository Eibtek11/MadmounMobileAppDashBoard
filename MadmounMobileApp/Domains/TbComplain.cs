using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbComplain
    {
        public Guid ComplainId { get; set; }
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
