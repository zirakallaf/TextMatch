namespace TextMatch.Helpers;

/// <summary>
/// Network Helper utility
/// </summary>
public class NetworkHelper
{
    const int startPort = 1;
    const int endPort = 65535;

    /// <summary>
    /// validates port number based on Internet Assigned Numbers Authority (IANA)
    /// </summary>
    /// <param name="port"></param>
    /// <returns></returns>
    public bool IsPortValid(int port)
    {
        if (port < startPort && port > endPort)
        {
            return false;
        }
        return true;
    }

}
