using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project4.Startup))]
namespace Project4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
