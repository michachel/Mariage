using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mariage.Startup))]
namespace Mariage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
