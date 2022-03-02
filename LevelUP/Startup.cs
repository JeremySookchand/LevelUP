using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LevelUP.Startup))]
namespace LevelUP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
