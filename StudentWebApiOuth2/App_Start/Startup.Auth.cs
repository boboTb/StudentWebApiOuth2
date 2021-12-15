using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StudentWebApiOuth2.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;

namespace StudentWebApiOuth2
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AppOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
                AllowInsecureHttp = true //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!
            };

          
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}