using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Entities
{
    public class Prize
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public DateTime? Duration { get; set; } = DateTime.Now.AddDays(30);
        public virtual List<PrizeItem>? PrizeItems { get; set; }
    }
    public class PrizeConfigurations : IEntityTypeConfiguration<Prize>
    {
        public void Configure(EntityTypeBuilder<Prize> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}