using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FCommerce.DataAcsess;
using FCommerce.DataAcsess.Repos.Implimentations;
using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.DataAcsess.Repos.UOWs;
using FCommerce.Website;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Configration.RegisterDependencies(builder.Services,builder.Configuration) ;

//builder.Services.AddDbContext<ApplicationDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
//});
//builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
//builder.Services.AddScoped<IProductRepo, ProductRepo>();
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
app.UseNotyf();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
