using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace LocalOnlyAccessTest.Authorization
{
    public class LocalOnlyAuthorizationAttribute : AuthorizeAttribute
    {
        private readonly IProvideIpAddresses _ipAddressProvider;

        public LocalOnlyAuthorizationAttribute()
        {
            _ipAddressProvider = new IpAddressProvider();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string requestIpAddress = httpContext.Request.UserHostAddress;

            if (string.IsNullOrEmpty(requestIpAddress)) { return false; }

            if (requestIpAddress == "127.0.0.1" || requestIpAddress == "::1") return true;

            string localIpAddress = _ipAddressProvider.GetLocalIp();

            return requestIpAddress == localIpAddress;
        }
    }
}