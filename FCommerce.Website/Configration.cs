using AspNetCoreHero.ToastNotification;
using FCommerce.DataAcsess;
using FCommerce.DataAcsess.Repos.UOWs;
using Microsoft.EntityFrameworkCore;

namespace FCommerce.Website
{
    public static class Configration
    {
        /// <summary>
        /// Register Your Dependencies
        /// </summary>
        /// <param name="builder">builder</param>
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });
            builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }






        //Old Wey To Set Configration

        ///// <summary>
        ///// Register Your Dependencies
        ///// </summary>
        ///// <param name="services">builder.Services</param>
        ///// <param name="configuration">builder.ConfigurationS</param>
        //public static void RegisterDependencies(IServiceCollection services,IConfiguration configuration)
        //{
        //    // Add services to the container.
        //    services.AddDbContext<ApplicationDbContext>(option =>
        //   {
        //       option.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        //   });
        // services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //}
    }
}
