using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_Projet_v_1_0_0.Models;
using DAL;

namespace BD_Projet_v_1_0_0.Controllers;

public class HomeController : Controller
{
    DAL_DAO dAL_DAO = new DAL_DAO();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Artists> artists = dAL_DAO.Getall("Artists");
        return View(artists);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult LogIn(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
