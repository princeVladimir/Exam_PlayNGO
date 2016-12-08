using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExtremeGym_App.Startup))]
namespace ExtremeGym_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
