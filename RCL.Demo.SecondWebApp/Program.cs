using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using RCL.Demo.SecondWebApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddAuthorization();

builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.AddTransient<IOfferVerificationService, OfferVerificationService>();
builder.Services.AddRCLCoreAuthTokenServices(options => builder.Configuration.Bind("Auth", options));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("Api"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
