using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosterShop.Data;

[assembly: HostingStartup(typeof(PosterShop.Areas.Identity.IdentityHostingStartup))]
namespace PosterShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PosterShopContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PosterShopContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PosterShopContext>();
            });
        }
    }
}