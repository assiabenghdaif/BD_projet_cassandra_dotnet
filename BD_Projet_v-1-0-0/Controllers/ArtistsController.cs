using System.Collections;
using System.Diagnostics;
using BD_Projet_v_1_0_0.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BD_Projet_v_1_0_0.Controllers;

public class ArtistsController : Controller {
    DAL_DAO dAL_DAO = new DAL_DAO();
    
    public IActionResult Edit(String id){
        List<Artists> artists = dAL_DAO.GetBy("Artists", "id", id);
        return View(artists[0]);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Artists artist)
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
                Console.WriteLine("liste des songs:" + artist.song);
            }
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