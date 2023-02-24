using EventBus.Base.Standard;
using EventBus.RabbitMQ.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Options;
using FitnessAppDemo.Data;
using FitnessAppDemo.Logging.Events;
using FitnessAppDemo.Logging.Services;
using FitnessAppDemo.Logic.Models;
using FitnessAppDemo.Logic.Services;
using FitnessAppDemo.Logic.Validators;
using FitnessAppDemo.Web.Configurations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// RabbitMQ
var rabbitMqOptions = builder.Configuration.GetSection("RabbitMq").Get<RabbitMqOptions>();

// Localization: Here we are adding in the localizaton service which will enable using IStringLocalizer in the CustomersController
builder.Services.AddLocalization(options => options.ResourcesPath = "FitnessAppDemo.Localization.Resources");

SwaggerConfiguration.Configure(builder);

// Get ConnectionString from appsettings.json
var connectionString = builder.Configuration.GetValue<string>("ProductDbConnection");

// Connection to PostgreSQL
builder.Services.AddDbContext<ProductContext>(options => {
    options.UseNpgsql(connectionString);
});

// Services dependency injection 
ServicesConfiguration.Configure(builder);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.Authority = "https://localhost:7241";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

//builder.Services.AddRabbitMqConnection(rabbitMqOptions);
//builder.Services.AddRabbitMqRegistration(rabbitMqOptions);

var app = builder.Build();

// TODO: move to Logging project
//var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<LogEvent, LogService>();

var supportedCultures = new[] { "en-US", "ru-RU" };
var localizationOptions =
    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

SwaggerConfiguration.UseSwagger(app);

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
