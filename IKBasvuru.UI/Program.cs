using IKBasvuru.COMMON.Models;
using IKBasvuru.COMMON.Services;
using IKBasvuru.DATA.Repositories.Abstract;
using IKBasvuru.DATA.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


//DIC for domain classes
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
builder.Services.AddScoped<IJobPositionRepository, JobPositionRepository>();

builder.Services.AddSession(s => { s.IdleTimeout = TimeSpan.FromMinutes(10); });

builder.Services.AddControllersWithViews();

if (builder.Configuration.GetValue<bool>("UseLDAPLogin"))
{
    // Authentication service
    builder.Services.Configure<LdapConfig>(builder.Configuration.GetSection("ldap"));
    builder.Services.AddScoped<IAuthenticationService, LdapAuthenticationService>();

    builder.Services.AddMvc(config =>
{
    // Requiring authenticated users on the site globally
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

    // Authentication
    var cookiesConfig = builder.Configuration.GetSection("cookies").Get<CookiesConfig>();

    builder.Services.AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = cookiesConfig.CookieName;
            options.LoginPath = cookiesConfig.LoginPath;
            options.LogoutPath = cookiesConfig.LogoutPath;
            options.AccessDeniedPath = cookiesConfig.AccessDeniedPath;
            options.ReturnUrlParameter = cookiesConfig.ReturnUrlParameter;
        });


    //policies are added in the account controller, after a valid login
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Require.Ldap.User", policy =>
                          policy.RequireClaim("aspnetcore.ldap.user", "true")
                                .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
                              );
    });
}

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

app.UseAuthorization();
app.UseAuthentication();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Application}/{id?}");
});

app.Run();
