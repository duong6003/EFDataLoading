using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class Gift
    {
        public string GiftCode { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public decimal? Value { get; set; }
    }
}