using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_Projet_v_1_0_0.Models;
using DAL;
using System.Dynamic;

namespace BD_Projet_v_1_0_0.Controllers;

public class HomeController : Controller
{
    DAL_DAO dAL_DAO = new DAL_DAO();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchTerm)
    {   List<Artists> nosArtists = dAL_DAO.Getall("Artists");
        IndexViewModel myModel = new IndexViewModel();
        myModel.artists = string.IsNullOrEmpty(searchTerm) ? nosArtists : nosArtists.Where(a =>
        a.Stage_Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        a.Full_Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        a.Original_group.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        a.Company.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        a.Gender.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
    .ToList();
        if (searchTerm!=null) { 
            ViewBag.SearchPerformed = true ;
            ViewBag.searchTermV=searchTerm;
        }
        string username = TempData["username"] as string;
        User user=dAL_DAO.getUserBy("user","username",username);
        myModel.userAuthentifie = user;
        TempData["username"]=username;
        return View(myModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult LogIn(){
        
        return View();
    }

    [HttpPost]
    public IActionResult LogIn(string username, string password)
    {
        User user1=dAL_DAO.getUserBy("user","username",username);
        if (user1 != null && VerifPassword(user1.password,password)){
            // IndexViewModel myModel=new IndexViewModel();
            // myModel.userAuthentifie=user1;
            TempData["username"] =username;
            return RedirectToAction("Index","Home");
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
