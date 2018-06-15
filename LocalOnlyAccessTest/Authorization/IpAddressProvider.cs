using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace LocalOnlyAccessTest.Authorization
{
    public class IpAddressProvider : IProvideIpAddresses
    {
        public ICollection<string> GetLocalIPs()
        {
            var localIpAddresses = NetworkInterface.GetAllNetworkInterfaces()
                                    .Where(i => i.OperationalStatus == OperationalStatus.Up)
                                    .SelectMany(i => i.GetIPProperties().UnicastAddresses)
                                    .Select(i => i.Address.ToString())
                                    .ToList();

            return localIpAddresses;
        }
    }
}