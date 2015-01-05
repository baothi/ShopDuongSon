using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopDuongSon.Startup))]
namespace ShopDuongSon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
