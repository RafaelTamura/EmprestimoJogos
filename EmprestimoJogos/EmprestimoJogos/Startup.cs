using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmprestimoJogos.Startup))]
namespace EmprestimoJogos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
