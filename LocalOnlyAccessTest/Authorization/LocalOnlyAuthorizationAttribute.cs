using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocalOnlyAccessTest.Authorization.Models;

namespace LocalOnlyAccessTest.Authorization
{
    public class LocalOnlyAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string requestIpAddress = httpContext.Request.UserHostAddress;

            if (string.IsNullOrEmpty(requestIpAddress)) { return false; }

            if (requestIpAddress == "127.0.0.1" || requestIpAddress == "::1") return true;
            
            var networkInfo = DependencyResolver.Current.GetService<NetworkInfo>();

            return networkInfo.LocalIpAddresses.Contains(requestIpAddress);
        }
    }
}