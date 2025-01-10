namespace UtilsNET.Net;

public static class InternetProtocol
{

    /// <summary>
    /// Retrieves the public IP address of the machine.
    /// </summary>
    /// <returns>
    /// A string representing the public IP address.
    /// </returns>
    /// <remarks>
    /// This method uses the ipify service to obtain the public IP address.
    /// </remarks>
    /// <exception cref="HttpRequestException">
    /// Thrown when there is an error in sending the HTTP request.
    /// </exception>
    public static string GetPublicIP()
    {
        string ip = string.Empty;
        HttpClient client = new();
        try
        {
            ip = client.GetAsync("https://api.ipify.org").Result.Content.ReadAsStringAsync().Result;
        }
        catch (Exception) { }
        finally
        {
            client.Dispose();
        }
        return ip;
    }
}