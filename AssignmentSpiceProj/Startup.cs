using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentSpiceProj.Startup))]
namespace AssignmentSpiceProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
