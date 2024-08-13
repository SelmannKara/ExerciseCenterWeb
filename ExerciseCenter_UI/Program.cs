using ExerciseCenter_UI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie
    (JwtBearerDefaults.AuthenticationScheme, opt => {
        opt.LoginPath = "/Login/Index/";
        opt.LogoutPath= "/Login/LogOut/";
        opt.AccessDeniedPath="/Pages/AccessDenied/";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite=SameSiteMode.Strict;
        opt.Cookie.SecurePolicy= CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "ExerciseCenterJwt";
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();



// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Admin route
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}/{id?}",
    defaults: new { controller = "Admin", action = "Index" });

app.Run();
