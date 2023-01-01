using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbNotification
    {
        public Guid NotificationId { get; set; }
        public string Id { get; set; }


        public string NotificationTitle { get; set; }

        public string NotificationText { get; set; }

        public string NotificationTo { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
