using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace LocalOnlyAccessTest.Authorization
{
    public class IpAddressProvider : IProvideIpAddresses
    {
        public string GetLocalIp()
        {
            var localIp = "";

            foreach (var item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.OperationalStatus != OperationalStatus.Up) continue;

                foreach (var ip in item.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIp = ip.Address.ToString();
                    }
                }
            }

            return localIp;
        }
    }
}