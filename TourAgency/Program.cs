using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TourAgency.Data;
using TourAgency.Data.Interfaces;
using TourAgency.Data.Repositories;
using TourAgency.Models;
using TourAgency.Services.Models;
using TourAgency.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOffer, OfferRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AuthDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.Configure<FormOptions>(o => {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
})
 .AddEntityFrameworkStores<AuthDbContext>()
 .AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = false;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    options.Cookie.SameSite = SameSiteMode.Unspecified;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
});



builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Сервис для работы с сессиями
builder.Services.AddScoped(sp => ShopCart.GetCart(sp)); //Персонализация корзины
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(googleOptions =>
    {
        googleOptions.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
        googleOptions.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
        googleOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie().AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        googleOptions.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        googleOptions.ClaimActions.MapJsonKey("urn:google:name", "name", "url");

    });

builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();

