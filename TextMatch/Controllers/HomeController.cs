using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextMatch.Models;

namespace TextMatch.Controllers;

/// <summary>
/// The Home controller default landing page.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Logger Instance
    /// </summary>
    private readonly ILogger<HomeController> logger;

    /// <summary>
    /// Overloaded controller logging instance
    /// </summary>
    /// <param name="logger">The log object injected into the class</param>
    public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Gets Home view.
    /// </summary>
    /// <returns>Home view object.</returns>
    /// <example> GET home </example>
    public IActionResult Index()
    {
        logger.LogInformation("The GET call of the Index method in Home Controller.");
        return View();
    }

    /// <summary>
    /// Gets About view.
    /// </summary>
    /// <returns>About view object.</returns>
    /// <example> GET About </example>
    public IActionResult AboutUs()
    {
        logger.LogInformation("The GET call of the About method in Home Controller.");
        return View();
    }

    /// <summary>
    /// Gets ContactUs view.
    /// </summary>
    /// <returns>About view object.</returns>
    /// <example> GET About </example>
    public IActionResult ContactUs()
    {
        logger.LogInformation("The GET call of the ContactUs method in Home Controller.");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogInformation("The GET call of the Error method in Home Controller.");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
