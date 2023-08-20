using System.Net;
using TextMatch.Helpers;
using TextMatch.Middlewares;
using TextMatch.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configure cors
string corsPolicy = "PolicyForClientApps";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        var origins = builder.Configuration.GetSection("AllowedHosts").Get<string>();

        if (!string.IsNullOrEmpty(origins))
        {
            var originList = origins.Split(';');
            policy.WithOrigins(originList);
        }
    });
});


var hstsConfig = builder.Configuration.GetRequiredSection("Hsts").Get<HstsConfig>();
if (!builder.Environment.IsDevelopment() && hstsConfig != null)
{
    if (hstsConfig.IsHstsEnabled)
    {
        // Https port configuration
        builder.Services.AddHttpsRedirection(options =>
        {
            var netHelper = new NetworkHelper();

            options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
            var defaultHttpsPort = 443;
            options.HttpsPort = netHelper.IsPortValid(hstsConfig.HttpsPort) ? hstsConfig.HttpsPort : defaultHttpsPort;
        });

        // HSTS configurations
        builder.Services.AddHsts(options =>
        {
            options.Preload = hstsConfig.IsPreload;
            options.IncludeSubDomains = hstsConfig.IncludeSubDomains;
            options.MaxAge = new TimeSpan(hstsConfig.MaxAgeByDay);
            foreach (var host in hstsConfig.ExcludedDomains)
            {
                options.ExcludedHosts.Add(host);
            }
        });
    }
}

var app = builder.Build();

app.UseCors(corsPolicy);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Additional security layer added to header
app.UseMiddleware<SecurityMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
