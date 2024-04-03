
using EcoWatchTan.Areas.Identity.Data;
using EcoWatchTan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EcoWatch.Models.ApiData;

namespace EcoWatchTan.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<WeatherDataAnalysisResult> WeatherDataAnalysisResults { get; set; }
	public DbSet<City> Cities { get; set; }
	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    public DbSet<EcoWatch.Models.ApiData.Weather> Weather { get; set; } = default!;
  
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<User>
{ public void Configure (EntityTypeBuilder<User> builder)
    {
builder.Property(u=>u.Neighborhood).HasMaxLength(256);

    }
}