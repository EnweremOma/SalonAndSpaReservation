using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalonAndSpaReservation.WebUI.Startup))]
namespace SalonAndSpaReservation.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
