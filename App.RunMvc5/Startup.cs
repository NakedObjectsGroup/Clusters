using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunMvc5.Startup))]
namespace RunMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
