using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_Projet_v_1_0_0.Models;
using DAL;
using System.Text;

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
        User user1=new User();
        return View(user1);
    }
    [HttpPost]
    public ActionResult LogIn(string username, string password)
    {
        User user1=dAL_DAO.getUserByUsername("user","username",username);
        if (user1 != null && VerifPassword(user1.password,password)){
            return RedirectToAction("Index");
        }
        ViewBag.Message = "UserName or password is wrong";
        return View("LogIn");
        
    }

    private bool VerifPassword(string password1, string password2)
    {
        return password1!=password2 ? false : true;
    }

    public IActionResult Success()
    {
        // Your logic for rendering the success view goes here
        return View("Home");
    }

    public IActionResult SignUp(){
        User user=new User();

        return View(user);
    }

    [HttpPost]
    public ActionResult SignUp(string username, string password,string lastname, string firstname)
    {
        User user=new Models.User{
            username=username,
            password=password,
            firstname=firstname,
            lastname=lastname,
        };
        bool rs=dAL_DAO.addUser("user",user);

        if (rs == true){
            return RedirectToAction("LogIn");
        }
        return View("SignUp");
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
