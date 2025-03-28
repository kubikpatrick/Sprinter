using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using Sprinter.Models;

namespace Sprinter.Controllers;

public sealed class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("privacy")]
    public ActionResult Privacy()
    {
        return View();
    }

    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public ActionResult Error()
    {
        return View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
    }
}
