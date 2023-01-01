using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbClients
    {
        public TbClients()
        {

            TbClientImagess = new HashSet<TbClientImages>();
            
        }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }

        public string ClientLogo { get; set; }


        public string ClientVideo { get; set; }


        public string ClientLocation { get; set; }


        public Guid CityId { get; set; }
        public string CityName { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<TbClientImages> TbClientImagess { get; set; }


    }
}
