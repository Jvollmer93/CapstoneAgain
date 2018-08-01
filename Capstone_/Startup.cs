using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone_.Startup))]
namespace Capstone_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
