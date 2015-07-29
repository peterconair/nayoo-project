using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Owin.Security;

namespace Nayoo.APIs.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //string tms_api_id;
            //string tms_api_key;
            //if (context.TryGetBasicCredentials(out tms_api_id, out tms_api_key))
            //{
            //    context.SetError("error", "Invalid Client Application ID !");
            //    return;
            //}


            //if ((!Configure.TMS_API_ID.Equals(tms_api_id)) &&
            //    (!Configure.TMS_API_KEY.Equals(tms_api_id)))
            //{
            //    context.SetError("error", "Invalid Client Application ID !");
            //    return;
            //}

            //context.OwinContext.Set<string>("as:clientAllowedOrigin", Configure.AllowOrigin);
            //context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", Configure.RefreRefreshTokenLifeTime.ToString());
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });


            //Connection Infomation 
            //string[] CustoAttribute;
            //if (!context.Request.Headers.TryGetValue("CustomAttribute", out CustoAttribute))
            //{
            //    context.SetError("invalid_grant", "Invalid CustomAttributes Header");
            //    return;
            //} 

            //if (string.IsNullOrEmpty(context.UserName))
            //{
            //    context.SetError("error", "Invalid User ID.");
            //    return;
            //}


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "User"));

            context.Validated(identity);
        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}