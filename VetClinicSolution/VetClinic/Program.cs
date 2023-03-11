using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Pgsql");

builder.Services.AddDbContext<VetClinicDbContext>(options => 
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name:"default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
