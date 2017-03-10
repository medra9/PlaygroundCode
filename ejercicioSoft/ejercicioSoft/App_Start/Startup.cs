using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using ejercicioSoft.App_Start;

[assembly: OwinStartup(typeof(ejercicioSoft.App_Code.Startup))]

namespace ejercicioSoft.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OwinConfig.ConfigureAuth(app);
        }
    }
}