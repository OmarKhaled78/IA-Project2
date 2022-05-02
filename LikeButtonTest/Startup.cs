using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LikeButtonTest.Startup))]
namespace LikeButtonTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
