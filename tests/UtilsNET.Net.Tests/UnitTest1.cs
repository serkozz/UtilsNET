using FluentAssertions;

namespace UtilsNET.Net.Tests;

public class InternetProtocolTests
{

    [Fact]
    public void GetPublicIP_ReturnsAnythingExceptLocalHost_WhenConnected()
    {
        var ip = InternetProtocol.GetPublicIP();
        ip.Should()
        .NotContain("192.168.")
        .And
        .NotContain("127.0.")
        .And
        .NotBeEmpty();
    }

    [Fact]
    public void GetPublicIP_ReturnsEmpty_WhenDisconnected()
    {
        NetworkManager.SwitchNetworkAdapter(on: false);
        string ip = InternetProtocol.GetPublicIP();
        NetworkManager.SwitchNetworkAdapter(on: true);
        ip.Should().BeEmpty();
    }
}