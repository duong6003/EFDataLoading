using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Gift>? Gifts { get; set; }
    public DbSet<Prize>? Prizes { get; set; }
    public DbSet<PrizeItem>? PrizeItems { get; set; }
    public DbSet<Scholarship>? Scholarships { get; set; }
    public DbSet<Student>? Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

}
