using System.Diagnostics;

namespace UtilsNET.Net;

public static class NetworkManager
{
    /// <summary>
    /// Enables or disables network adapters on the system.
    /// </summary>
    /// <param name="on">If set to <c>true</c>, enables all network adapters; otherwise, disables them.</param>
    /// <param name="adapterName">The name of the network adapter to enable or disable.</param>
    /// <remarks>
    /// This method uses powershell to enable or disable all network adapters on the system.
    /// </remarks>
    /// <exception cref="IOException">
    /// Thrown when there is an error in sending data to process input stream.
    /// </exception>
    public static void SwitchNetworkAdapter(string adapterName = "*", bool on = true)
    {
        string command = $@"{(on ? "Enable" : "Disable")}-NetAdapter -Name ""{adapterName}""";

        var startInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = $"-NoLogo -NoProfile -Command \"{command}\"",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = false,
            Verb = "runas"
        };

        using var process = new Process { StartInfo = startInfo };
        process.Start();

        StreamReader outputReader = process.StandardOutput;
        StreamReader errorReader = process.StandardError;
        StreamWriter inputWriter = process.StandardInput;

        while (!process.HasExited)
        {
            try
            {
                inputWriter.WriteLine();
            }
            catch (IOException)
            {
                break;
            }

        }
        process.WaitForExit();
    }
}