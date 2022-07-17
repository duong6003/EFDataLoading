using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class PrizeItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? GiftCode { get; set; }
        [ForeignKey("GiftCode")]
        public Gift? Gift { get; set; }
        public string? ScholarshipCode { get; set; }
        [ForeignKey("ScholarshipCode")]
        public Scholarship? Scholarship { get; set; }
    }
}