using FitnessAppDemo.Auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get ConnectionString from appsettings.json
var connectionString = builder.Configuration.GetValue<string>("ProductDbConnection");

// Connection to PostgreSQL
builder.Services.AddDbContext<UserContext>(options => {
    options.UseNpgsql(connectionString);
});

builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(Config.GetApiScopes())
    .AddInMemoryApiResources(Config.GetApiResources())
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddTestUsers(Config.GetTestUsers())
    .AddInMemoryClients(Config.GetClients());

var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
//app.UseAuthentication();
//app.UseAuthorization();


app.MapGet("/", () => "Hello World!");

app.Run();
