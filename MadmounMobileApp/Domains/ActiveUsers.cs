using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class ActiveUsers
    {
        [Key]
        public string Id { get; set; }
        public int count { get; set; }
    }
}
