using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BombayTools.Startup))]
namespace BombayTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
