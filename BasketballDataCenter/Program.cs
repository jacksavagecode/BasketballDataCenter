using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BasketballDataCenter.Models;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("BasketballDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'BasketballDbContextConnection' not found.");

// Register the DbContext with the connection string
builder.Services.AddDbContext<BasketballDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Default Identity with required configurations
builder.Services.AddDefaultIdentity<User>(options =>
{
    // Configure password requirements
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.@";

    // Configure other identity options
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()  // Add roles support
    .AddEntityFrameworkStores<BasketballDbContext>()  // Use EF Core to store identity data
    .AddDefaultTokenProviders();  // Optional: Add token providers for functionalities like password reset, email confirmation, etc.

// Add services to the container
builder.Services.AddControllersWithViews();  // For MVC support
builder.Services.AddRazorPages();  // For Razor Pages support

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages and Controllers
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
