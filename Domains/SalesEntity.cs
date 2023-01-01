using System;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class SalesEntity
    {
        [Key]
        public string CityName { get; set; }
        public int count { get; set; }
    }
}
