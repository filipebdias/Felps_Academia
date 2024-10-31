using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademiaoUltimo.Startup))]
namespace AcademiaoUltimo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
