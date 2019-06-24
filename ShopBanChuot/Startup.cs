
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopBanChuot.Startup))]
namespace ShopBanChuot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
