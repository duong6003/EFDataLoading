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
    public class PrizeItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? PrizeId { get; set; }
        [ForeignKey("PrizeId")]
        public Prize? Prize { get; set; }
        public string? GiftCode { get; set; }
        [ForeignKey("GiftCode")]
        public Gift? Gift { get; set; }
        public string? ScholarshipCode { get; set; }
        [ForeignKey("ScholarshipCode")]
        public Scholarship? Scholarship { get; set; }
    }
    public class PrizeItemConfigurations : IEntityTypeConfiguration<PrizeItem>
    {
        public void Configure(EntityTypeBuilder<PrizeItem> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}