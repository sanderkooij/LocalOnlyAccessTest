using System.Collections.Generic;

namespace LocalOnlyAccessTest.Authorization
{
    public interface IProvideIpAddresses
    {
        ICollection<string> GetLocalIPs();
    }
}