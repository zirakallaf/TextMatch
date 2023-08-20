using Microsoft.Extensions.Primitives;

namespace TextMatch.Middlewares;

public class SecurityMiddleware
{
    /// <summary>
    /// request delegate
    /// </summary>
    private readonly RequestDelegate next;
    private readonly ILogger logger;

    public SecurityMiddleware(IConfiguration configuration, RequestDelegate next, ILoggerFactory logger)
    {
        this.next = next;
        this.logger = logger.CreateLogger<SecurityMiddleware>();
    }

    public async Task Invoke(HttpContext context)
    {
        logger.LogInformation("Add security headers.");
        context.Response.Headers.Add("Strict-Transport-Security", new StringValues("x-xss-protection"));

        // additrional securit headers can be added based on business requirements.

        await next.Invoke(context);
    }

}
