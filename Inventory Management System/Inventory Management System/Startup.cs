using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Inventory_Management_System.Startup))]
namespace Inventory_Management_System
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}