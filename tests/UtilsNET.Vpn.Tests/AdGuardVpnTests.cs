using UtilsNET.Vpn.AdGuard;
using FluentAssertions;
using System.Diagnostics;

namespace UtilsNET.Vpn.Tests;

public class UnitTest1
{
    [Fact]
    public void AdGuardVpnProvider_SuccesfullyCreated()
    {
        AdGuardVpnProvider provider = new(autoConnect: true);
        provider.Disconnect();
        provider.Should().NotBeNull();
    }
}
