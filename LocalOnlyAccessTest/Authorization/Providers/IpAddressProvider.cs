using System.Linq;
using System.Net.NetworkInformation;
using LocalOnlyAccessTest.Authorization.Models;

namespace LocalOnlyAccessTest.Authorization.Providers
{
    public class IpAddressProvider : IProvideIpAddresses
    {
        public NetworkInfo GetLocalIPs()
        {
            var localIpAddresses = NetworkInterface.GetAllNetworkInterfaces()
                                    .Where(i => i.OperationalStatus == OperationalStatus.Up)
                                    .SelectMany(i => i.GetIPProperties().UnicastAddresses)
                                    .Select(i => i.Address.ToString())
                                    .ToList();

            return new NetworkInfo(localIpAddresses);
        }
    }
}