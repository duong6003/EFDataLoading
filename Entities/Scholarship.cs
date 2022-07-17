using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class Scholarship
    {
        [Key]
        public string ScholarshipCode { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public decimal? Value { get; set; }
        public ScholarshipType ScholarshipType { get; set; } = ScholarshipType.Half;
    }
    public enum ScholarshipType
    {
        All = 1,
        Half = 2
    }
}