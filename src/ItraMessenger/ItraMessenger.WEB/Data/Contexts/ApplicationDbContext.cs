using ItraMessenger.ApplicationCore.Models;
using ItraMessenger.Infrastructure.Identity;
using ItraMessenger.WEB.Data.Converters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItraMessenger.WEB.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Message> Messages { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected sealed override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetToUtcConverter>();
    }
}