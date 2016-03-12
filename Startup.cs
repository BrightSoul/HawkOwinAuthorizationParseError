using HawkNet;
using HawkNet.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkOwinAuthorizationParseError
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseHawkAuthentication(new HawkAuthenticationOptions {
                  Credentials = id => Task.FromResult(new HawkCredential { Id = id, Key = "aaa", User = "bob", Algorithm = "sha256"  }),
                  IncludeServerAuthorization = true
            });
            
            app.Run(async context =>
            {
                bool authenticated = context.Authentication != null && context.Authentication.User != null && context.Authentication.User.Identity.IsAuthenticated;
                    await context.Response.WriteAsync(string.Format("You are authenticated: {0}", authenticated));
            });
        }
    }
}
