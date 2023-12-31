using HastaneRandevuSistemi.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using static HastaneRandevuSistemi.Services.LanguageService;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "Aktif";
    options.LoginPath = "/Authentication/GirisYap";
    options.AccessDeniedPath = "/Authentication/GirisYap";
    options.ExpireTimeSpan = TimeSpan.FromSeconds(1200);
});
#region Localizer
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(
    options=>options.DataAnnotationLocalizerProvider= (type , factory) =>
{
    var assemblyName =new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
    return factory.Create(nameof(SharedResource), assemblyName.Name);
});
builder.Services.Configure<RequestLocalizationOptions>(options => {

    var supportCultures = new List<CultureInfo> {
    new CultureInfo("en-US"),
    new CultureInfo("tr-TR"),

    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR" , uiCulture: "tr-TR");
    options.SupportedCultures = supportCultures;
    options.SupportedUICultures = supportCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
#endregion

void ConfigureServices(IServiceCollection services)
{
    services.AddHostedService<TimedBackgroundService>();
}

//ConfigureServices(builder.Services);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=AnaSayfa}/{id?}");

app.Run();

