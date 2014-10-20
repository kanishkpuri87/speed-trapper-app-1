using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(speed_trapper.Startup))]
namespace speed_trapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            var config = new HubConfiguration();
            config.EnableJSONP = true;
            config.EnableDetailedErrors = true;
            
            
            app.MapSignalR(config);
        }
    }
}
