using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(autenticacion.Startup))]
namespace autenticacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
