using System.Diagnostics;
using Microsoft.Win32;

namespace UtilsNET.Vpn.AdGuard;

public class AdGuardVpnProvider : IVpnProvider
{
    private const string APP_REGISTRY_PATH = $@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\adguardvpn.exe";
    
    private readonly Process _underlyingProcess;

    public AdGuardVpnProvider(bool autoConnect = false)
    {
        _underlyingProcess = CreateUnderlyingProcess();
        if (autoConnect)
            Connect();
    }

    private static string GetAdGuardPath()
    {
        if (OperatingSystem.IsWindows())
        {
            using RegistryKey? key = Registry.LocalMachine.OpenSubKey(APP_REGISTRY_PATH);
            if (key is null)
                throw new ArgumentNullException(nameof(key), $@"Can't get registry key containing adguard .exe path (RegistryPath: {APP_REGISTRY_PATH})");
            string? appPath = key.GetValue("", "") as string;
            ArgumentNullException.ThrowIfNull(appPath);
            return appPath;
        }
        throw new NotSupportedException();
    }

    private static Process CreateUnderlyingProcess()
    {
        var process = new Process();
        process.StartInfo.FileName = GetAdGuardPath();
        process.StartInfo.Arguments = "--connect";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = true;
        return process;
    }

    public void Connect()
    {
        _underlyingProcess.Start();
    }

    public void Disconnect()
    {
        _underlyingProcess.Kill();
    }
}