using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using fyp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.IsEssential = true;
});





var connectionString = builder.Configuration.GetConnectionString("fypContextConnection") ?? throw new InvalidOperationException("Connection string 'fypContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultUI().AddDefaultTokenProviders();

builder.Services.AddAuthorization(builder =>
{
    builder.AddPolicy("Corporation", policy => policy.RequireRole("Corporation","Admin","Student"));

    builder.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

});






builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();


using (var scope = app.Services.CreateScope())
{
    var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "admin", "Student", "Company" };
    foreach (var role in roles)
    {
        if (!await rolemanager.RoleExistsAsync(role))
        {
            await rolemanager.CreateAsync(new IdentityRole(role));
        }
    }
}

using(var scope = app.Services.CreateScope())
{
    var Usermanager=scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "Admin@gmail.com";
    string password = "Admin123#";
    if (await Usermanager.FindByEmailAsync(email)==null)
    {
        var user = new IdentityUser();
        user.Email = email;
        user.UserName = email;
        await Usermanager.CreateAsync(user,password);

        await Usermanager.AddToRoleAsync(user, "admin");
    }

    
}





app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=jobs}/{action=Index}/{id?}");

app.Run();
