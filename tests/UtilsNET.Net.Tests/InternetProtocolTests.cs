using FluentAssertions;
using System.Net;

namespace UtilsNET.Net.Tests;

public class InternetProtocolTests
{
    [Fact]
    public async Task GetPublicIPAsync_ReturnsAnythingExceptLocalHost_WhenConnected()
    {
        var ip = await InternetProtocol.GetPublicIPAsync();
        ip.Value.Should().NotBeNull();
        ip.Value.Should()
        .NotContain("192.168.")
        .And
        .NotContain("127.0.")
        .And
        .NotBeEmpty();
    }

    [Fact]
    public async Task GetIPInfoAsync_ReturnsAnythingExceptLocalHost_WhenConnected()
    {
        var ipInfo = await InternetProtocol.GetIpInfoAsync(ip: new IPAddress([8, 8, 8, 8]));
        ipInfo.IsSuccess.Should().BeTrue();
        ipInfo.Value.Should().NotBeNull();
        ipInfo.Value!.Query.Should().NotContain("192.168.").And.NotContain("127.0.");
    }


    // Beware: May fail another tests (cause of disabling network adapter)
    [Fact]
    public async Task GetPublicIPAsync_ReturnsFailureResult_WhenDisconnected()
    {
        NetworkManager.SwitchNetworkAdapter(on: false);
        bool isSuccess = (await InternetProtocol.GetPublicIPAsync()).IsSuccess;
        NetworkManager.SwitchNetworkAdapter(on: true);
        isSuccess.Should().BeFalse();
    }


    // Beware: May fail another tests (cause of disabling network adapter)
    [Fact]
    public async Task GetIPInfoAsync_HasErrors_WhenDisconnected()
    {
        NetworkManager.SwitchNetworkAdapter(on: false);
        var result = await InternetProtocol.GetIpInfoAsync(new IPAddress([8, 8, 8, 8]));
        NetworkManager.SwitchNetworkAdapter(on: true);
        result.Errors.Should().NotBeEmpty();
    }
}