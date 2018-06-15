using LocalOnlyAccessTest.Authorization.Models;

namespace LocalOnlyAccessTest.Authorization.Providers
{
    public interface IProvideIpAddresses
    {
        NetworkInfo GetLocalIPs();
    }
}