using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextMatch.Models;
using TextMatch.Services;

namespace TextMatch.Controllers;

/// <summary>
/// The TextManipulation controller for searching subtext in a text.
/// </summary>
public class TextManipulationController : Controller
{
    /// <summary>
    /// Logger Instance
    /// </summary>
    private readonly ILogger<TextManipulationController> _logger;

    /// <summary>
    /// Reference to the text manipulation service.
    /// </summary>
    readonly TextManipulations textManipulations;

    /// <summary>
    /// Overloaded controller logging instance
    /// </summary>
    /// <param name="logger">The log object injected into the class</param>
    public TextManipulationController(ILogger<TextManipulationController> logger)
    {
        _logger = logger;
        textManipulations = new();
    }

    /// <summary>
    /// Gets TextManipulation view.
    /// </summary>
    /// <returns>TextManipulation view object.</returns>
    /// <example> GET textmanipulation </example>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Gets TextMatch view.
    /// </summary>
    /// <returns>TextMatch view object.</returns>
    /// <example> GET textmanipulation/TextMatch </example>
    public IActionResult TextMatch()
    {
        return View();
    }

    /// <summary>
    /// Gets result of the search.
    /// </summary>
    /// <param name="TextForFrequency">The TextForFrequency contains SubText and Text to find frequency.</param>
    /// <returns>A list of the search positions in a text format separated by comma or not fount message.</returns>
    /// <example>POST textmanipulation/TextMatch</example>
    [HttpPost]
    public IActionResult TextMatch(TextForFrequency TextForFrequency)
    {
        _logger.LogInformation("The POST call of the TextMatch method in TextManipulation Controller.");
        if (!ModelState.IsValid)
        {
            return View();
        }

        ViewBag.TextMatchResult = textManipulations.FindSubTextFrequency(TextForFrequency);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
