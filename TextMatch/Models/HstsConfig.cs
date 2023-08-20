namespace TextMatch.Services;

public class HstsConfig
{
    /// <summary>
    /// this flag indicates enabled/disable HSTS of the API
    /// </summary>
    public bool IsHstsEnabled { get; set; }
    /// <summary>
    /// secure port used by https
    /// </summary>
    public int HttpsPort { get; set; }
    /// <summary>
    /// max age
    /// </summary>
    public int MaxAgeByDay { get; set; }
    /// <summary>
    /// include sub domain
    /// </summary>
    public bool IncludeSubDomains { get; set; }
    /// <summary>
    /// included domains and subdomains
    /// </summary>
    public required List<string> ExcludedDomains { get; set; }
    /// <summary>
    /// preload flag
    /// </summary>
    public bool IsPreload { get; set; }

}
