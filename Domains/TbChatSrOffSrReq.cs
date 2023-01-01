using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbChatSrOffSrReq
    {
        public Guid MessagesId { get; set; }
        public string MemberId { get; set; }
        public string MessageText { get; set; }
        public string ToSendId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? AreaId { get; set; }
        public Guid? SrRepId { get; set; }

        public virtual TbArea Area { get; set; }
        public virtual TbCity City { get; set; }
        public virtual TbService Service { get; set; }
    }
}
