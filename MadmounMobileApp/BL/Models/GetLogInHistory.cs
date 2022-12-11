using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class GetLogInHistory
    {
        public Guid LogInId { get; set; }
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
