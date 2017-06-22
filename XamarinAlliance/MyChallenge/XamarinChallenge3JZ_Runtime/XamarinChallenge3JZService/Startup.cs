using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinChallenge3JZService.Startup))]

namespace XamarinChallenge3JZService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}