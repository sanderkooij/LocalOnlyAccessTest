using System.Collections.Generic;

namespace LocalOnlyAccessTest.Authorization.Models
{
    public class NetworkInfo
    {
        public IReadOnlyCollection<string> LocalIpAddresses { get; set; }

        public NetworkInfo()
            : this(new List<string>())
        {
            
        }

        public NetworkInfo(IReadOnlyCollection<string> localIpAddresses)
        {
            LocalIpAddresses = localIpAddresses;
        }
    }
}