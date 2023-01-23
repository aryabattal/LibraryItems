using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ManageLibraryItemsAndEmployees.Areas.Identity.IdentityHostingStartup))]
namespace ManageLibraryItemsAndEmployees.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}