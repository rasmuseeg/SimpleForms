using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleForms.Startup))]
namespace SimpleForms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
