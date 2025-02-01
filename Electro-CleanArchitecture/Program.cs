using Electro.Infrastructure;
using Electro.Services;
using Electro.Core;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Electro.Core.Middlewares;
using Stripe;
using Electro.Data.Helper;
using Microsoft.AspNetCore.SignalR;
using Electro.Core.HUB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureDependancies()
    .AddServicesDependancies(builder.Configuration)
    .ServicesRegisteration(builder.Configuration)
    .AddCoreDependancies();



#region Localization 
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ar-EG")
        };

    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion
#region Cors
var Cors = "_cors";
builder.Services.AddCors(options =>
  options.AddPolicy(name: Cors, builder =>
  {
      builder.AllowAnyHeader();
      builder.AllowAnyMethod();
      builder.AllowAnyOrigin();
  }
      )
);
#endregion


#region Stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
#endregion

#region SignalR
builder.Services.AddSignalR();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseCors(Cors);
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<chatHub>("/chatHub");

app.MapControllers();

app.Run();
