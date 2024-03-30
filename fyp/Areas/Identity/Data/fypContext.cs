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


        public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<CorporationModel> corporations{ get; set; }
    public DbSet<JobsModel> jobs { get; set; }

public DbSet<fyp.Models.SkillsModel> SkillsModel { get; set; } = default!;

public DbSet<fyp.Models.StudentModel> StudentModel { get; set; } = default!;

public DbSet<fyp.Models.QualificationModel> QualificationModel { get; set; } = default!;

public DbSet<fyp.Models.ApplicationModel> ApplicationModel { get; set; } = default!;


}
