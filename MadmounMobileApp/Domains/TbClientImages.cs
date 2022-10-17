using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbClientImages
    {
        public Guid ClientImageId { get; set; }
        public string ClientImage { get; set; }

        public string ImageState { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }


        public Guid? ClientId { get; set; }
        public virtual TbClients client { get; set; }
    }
}
