using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using fyp.Data;
using Microsoft.Extensions.DependencyInjection;
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

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

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


app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=jobs}/{action=Index}/{id?}");

app.Run();
