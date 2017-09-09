using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arkanis.WebSite.Startup))]
namespace Arkanis.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
