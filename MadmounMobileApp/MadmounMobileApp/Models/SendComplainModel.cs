using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Models
{
    public class SendComplainModel
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
