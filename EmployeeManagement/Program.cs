using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your singleton service
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

// Configure the DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Replace "YourConnectionStringName" with the name of your connection string
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection"));
});

// Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DeleteRolePolicy", policy =>
    {
        policy.RequireClaim("Delete Role");
    });
    options.AddPolicy("EditRolePolicy", policy =>
    {
        policy.RequireClaim("Edit Role");
    });
    options.AddPolicy("AdminRolePolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Enable the developer exception page middleware
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
