namespace UtilsNET.Common;
public class Error(string code, string message, Dictionary<string, object>? metadata = null)
{
    public string Code { get; } = code;
    public string Message { get; } = message;
    public Dictionary<string, object>? Metadata { get; } = metadata;

    public override string ToString() => $"{Code}: {Message}";
}