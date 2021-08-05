using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using musicrush.Areas.Identity.Data;

[assembly: HostingStartup(typeof(musicrush.Areas.Identity.IdentityHostingStartup))]
namespace musicrush.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<musicrushIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("musicrushIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<musicrushIdentityDbContext>();
            });
        }
    }
}