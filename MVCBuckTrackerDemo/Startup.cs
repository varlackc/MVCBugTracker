using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBugTrackerDemo.Startup))]
namespace MVCBugTrackerDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
