using Microsoft.EntityFrameworkCore;
using Rubay.Web.App.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Rubay.Web.App.Areas.Identity.IdentityHostingStartup))]
namespace Rubay.Web.App.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) => {
            services.AddDbContext<AccountDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("AccountDbContextConnection")));

            services.AddDefaultIdentity<AccountUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AccountDbContext>();
        });
    }
}