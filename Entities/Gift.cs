using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Entities;
public class Gift
{
    public string GiftCode { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public decimal? Value { get; set; }
}
public class GiftConfigurations : IEntityTypeConfiguration<Gift>
{
    public void Configure(EntityTypeBuilder<Gift> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.GiftCode);
    }
}