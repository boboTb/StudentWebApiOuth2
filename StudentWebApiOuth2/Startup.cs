
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StudentWebApiOuth2.OAuth;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(StudentWebApiOuth2.Startup))]

namespace StudentWebApiOuth2
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app);
        }
    }
}
