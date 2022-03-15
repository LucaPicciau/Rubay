using Microsoft.AspNetCore.Mvc;
using Rubay.Web.App.Models;
using System.Diagnostics;

namespace Rubay.Web.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        ErrorViewModel errorViewModel = new(Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        return View(errorViewModel);
    }
}