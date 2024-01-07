using System.Diagnostics;
using BD_Projet_v_1_0_0.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BD_Projet_v_1_0_0.Controllers;

public class ArtistsController : Controller {
    DAL_DAO dAL_DAO = new DAL_DAO();
    List<string> songsToDelete = new List<string>();
    
    [HttpPost]
    public IActionResult DeleteSong(string id){
        songsToDelete.Add(id);
        Console.WriteLine("songs To Delete: " + songsToDelete);
        return Json(new {success = true});
    }

    // [HttpPost]
    // public IActionResult AddSong(string index){
    //     try{
    //         songsToDelete.Add(int.Parse(index));
    //         Console.WriteLine("songs To Delete: " + songsToDelete);
    //         return Json(new {success = true});
    //     }catch{
    //         return Json(new {success = false});
    //     }
    // }

    public IActionResult Edit(String id){
        List<Artists> artists = dAL_DAO.GetBy("Artists", "id", id);
        return View(artists[0]);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Artists artist,IndexViewModel myModel)
    {
        try{
            if (artist != null){
                dAL_DAO.update("Artists", "Stage_Name", artist.Stage_Name, artist.ID);
                dAL_DAO.update("Artists", "Full_Name", artist.Full_Name, artist.ID);
                dAL_DAO.update("Artists", "Date_of_Birth", artist.Date_of_Birth, artist.ID);
                dAL_DAO.update("Artists", "Original_group", artist.Original_group, artist.ID);
                dAL_DAO.update("Artists", "Debut", artist.Debut, artist.ID);
                dAL_DAO.update("Artists", "Company", artist.Company, artist.ID);
                dAL_DAO.update("Artists", "Country", artist.Country, artist.ID);
                dAL_DAO.update("Artists", "Height", artist.Height, artist.ID);
                dAL_DAO.update("Artists", "Weight", artist.Weight, artist.ID);
                dAL_DAO.update("Artists", "Birthplace", artist.Birthplace, artist.ID);
                dAL_DAO.update("Artists", "Gender", artist.Gender, artist.ID);
                //dAL_DAO.update("Artists", "song", artist.song, artist.ID);
                //Console.WriteLine("liste des songs:" + artist.song);
            }
            string username = TempData["username"] as string;
            User user=dAL_DAO.getUserBy("user","username",username);
            myModel.userAuthentifie = user;
            return RedirectToAction("Index", "Home");
        }catch{
            return View();
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}