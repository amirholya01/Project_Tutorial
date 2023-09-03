using Microsoft.EntityFrameworkCore;
using Project.Core.Services;
using Project.Core.Services.Interfaces;
using Project.Datalayer.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserService, UserService>();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();
//app.MapGet("/", () => "Hello World!");

app.Run();