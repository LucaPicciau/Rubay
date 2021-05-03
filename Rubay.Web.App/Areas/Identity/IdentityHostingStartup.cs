using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rubay.Web.App.Areas.Identity.Data;
using Rubay.Web.App.Data;

[assembly: HostingStartup(typeof(Rubay.Web.App.Areas.Identity.IdentityHostingStartup))]
namespace Rubay.Web.App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RubayWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RubayWebAppContextConnection")));

                services.AddDefaultIdentity<RubayWebAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<RubayWebAppContext>();
            });
        }
    }
}