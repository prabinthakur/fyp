using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using fyp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace fyp.Data;

public class fypContext : IdentityDbContext<IdentityUser>
{
    public fypContext(DbContextOptions<fypContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<fyp.Models.Category> Category { get; set; } = default!;

    public DbSet<Vaccancy> Vaccancy { get; set;} = default!;
    
    public DbSet<Corporation> corporations { get; set; } = default!;
    public DbSet<Student> students { get; set; } = default!;


}
