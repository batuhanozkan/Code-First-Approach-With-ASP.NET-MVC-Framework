using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hikayeyaziyoruz.Startup))]
namespace hikayeyaziyoruz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
