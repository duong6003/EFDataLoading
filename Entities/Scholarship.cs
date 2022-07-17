using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Entities
{
    public class Scholarship
    {
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
    public class ScholarshipConfigurations : IEntityTypeConfiguration<Scholarship>
    {
        public void Configure(EntityTypeBuilder<Scholarship> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.ScholarshipCode);
        }
    }
}