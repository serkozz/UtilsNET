using System.Net.Http.Json;
using System.Text.Json;
using UtilsNET.Common;
using System.Net;

namespace UtilsNET.Net;

public static class InternetProtocol
{
    private static readonly HttpClient _httpIpapi = new()
    {
        BaseAddress = new Uri("http://www.ip-api.com/"),
    };

    private static readonly HttpClient _httpIpify = new()
    {
        BaseAddress = new Uri("https://api.ipify.org"),
    };

    /// <summary>
    /// Asynchronously retrieves the public IP address of the machine using the ipify service.
    /// </summary>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the public IP address as a string if successful, or an error if the request fails.
    /// </returns>
    /// <remarks>
    /// This method performs an asynchronous HTTP request to the ipify service to obtain the public IP address.
    /// In case of an error (e.g., network issues), it returns a failure result with the exception details.
    /// </remarks>
    /// <exception cref="HttpRequestException">
    /// Thrown when an HTTP request fails, typically due to network issues or invalid responses.
    /// </exception>
    public static async Task<Result<string>> GetPublicIPAsync()
    {
        try
        {
            var response = await _httpIpify.GetStringAsync("");
            return Result<string>.Success(response);
        }
        catch (HttpRequestException ex)
        {
            return Result<string>.Failure(ex);
        }
    }

    /// <summary>
    /// Retrieves geographical and network information about the given IP address (45 times per minute).
    /// </summary>
    /// <param name="ip">The IP address to look up.</param>
    /// <returns>
    /// An <see cref="IpInfo"/> object containing details about the IP,
    /// or <c>null</c> if the request fails.
    /// </returns>
    public static async Task<Result<IpInfo>> GetIpInfoAsync(IPAddress ip)
    {
        try
        {
            HttpResponseMessage response = await _httpIpapi.GetAsync($"json/{ip}?fields=66846719").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var parsedOrNull = await response.Content.ReadFromJsonAsync<IpInfo>().ConfigureAwait(false) ?? throw new JsonException($@"Can't parse response content to {nameof(IpInfo)} object");
            return Result<IpInfo>.Success(parsedOrNull);
        }
        catch (HttpRequestException ex)
        {
            return Result<IpInfo>.Failure(ex);
        }
        catch (TaskCanceledException ex)
        {
            return Result<IpInfo>.Failure(ex);
        }
        catch (Exception ex)
        {
            return Result<IpInfo>.Failure(ex);
        }
    }
}

public class IpInfo
{
    public string? Status { get; set; }
    public string? Continent { get; set; }
    public string? ContinentCode { get; set; }
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? Region { get; set; }
    public string? RegionName { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Zip { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string? Timezone { get; set; }
    public int Offset { get; set; }
    public string? Currency { get; set; }
    public string? Isp { get; set; }
    public string? Org { get; set; }
    public string? As { get; set; }
    public string? Asname { get; set; }
    public string? Reverse { get; set; }
    public bool Mobile { get; set; }
    public bool Proxy { get; set; }
    public bool Hosting { get; set; }
    public string? Query { get; set; }
}
