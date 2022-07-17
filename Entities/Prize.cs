using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class Prize
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public DateTime? Duration { get; set; } = DateTime.Now.AddDays(30);
        public virtual List<PrizeItem>? PrizeItems { get; set; }
    }
}