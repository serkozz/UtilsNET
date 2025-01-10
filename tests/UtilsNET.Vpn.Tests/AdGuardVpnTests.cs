using UtilsNET.Vpn.AdGuard;
using FluentAssertions;

namespace UtilsNET.Vpn.Tests;

public class UnitTest1
{
    [Fact]
    public void AdGuardVpnProvider_SuccesfullyCreated()
    {
        AdGuardVpnProvider provider = new(autoConnect: true);
        provider.Should().NotBeNull();
    }
}
