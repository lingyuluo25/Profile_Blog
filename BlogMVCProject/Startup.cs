using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogMVCProject.Startup))]
namespace BlogMVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
