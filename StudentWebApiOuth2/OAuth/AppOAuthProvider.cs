
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Models.Model;
using StudentBL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace StudentWebApiOuth2.OAuth
{
    public class AppOAuthProvider:OAuthAuthorizationServerProvider
    {
        #region Grant resource owner credentials override method.

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Initialization.
            string usernameVal = context.UserName;
            string passwordVal = context.Password;
            string _connection = ConfigurationManager.ConnectionStrings["StudentskaSluzba_Database"].ConnectionString;
            UserBusiness userBusiness = new UserBusiness(_connection);
            User user = await userBusiness.GetUser(usernameVal, passwordVal);

            // Verification.
            if (user == null)
            {
                // Settings.
                context.SetError("invalid_grant", "The user name or password is incorrect.");

                // Retuen info.
                return;
            }

            // Initialization.
            var claims = new List<Claim>();
            var userInfo = user;

            //// Setting
            //claims.Add(new Claim(ClaimTypes.Name, userInfo.UserName));

            //// Setting Claim Identities for OAUTH 2 protocol.
            ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(null, OAuthDefaults.AuthenticationType);
            //ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

            // Setting user authentication.
            //AuthenticationProperties properties = CreateProperties(userInfo.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, null);

            // Grant access to authorize user.
            context.Validated(ticket);
            //context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }


        #endregion
    }
}