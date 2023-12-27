using BD_Projet_v_1_0_0.Models;
using DAL;

namespace BD_Projet_v_1_0_0
{
    public class Program{
            public static void Main(string[] args)
                {
                    var builder = WebApplication.CreateBuilder(args);

                    // Add services to the container.
                    builder.Services.AddControllersWithViews();

                    var app = builder.Build();

                    // Configure the HTTP request pipeline.
                    if (!app.Environment.IsDevelopment())
                    {
                        app.UseExceptionHandler("/Home/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                    }

                    app.UseHttpsRedirection();
                    app.UseStaticFiles();

                    app.UseRouting();

                    app.UseAuthorization();

                    app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    DAL_DAO dAL_DAO = new DAL_DAO();
                    Console.WriteLine("get all");
                    List<Artists> artists1=dAL_DAO.Getall("artists");
                    foreach (var row in artists1)
                    {
                        Console.WriteLine(row.ToString());
                    }
                    Console.WriteLine("\n\nget one by what you want");
                    
                    // dAL_DAO.GetBy("artists","song","Still Life",out artist,out artists); //by song
                    List<Artists> artists=dAL_DAO.GetBy("artists","id","da8658db-53a7-454a-b69c-ef25f14995ea"); //by id
                    foreach (var row in artists)
                    {
                        Console.WriteLine(row.ToString());
                    }
                    
                    // //insert test
                    // bool t=artist!=null?dAL_DAO.insert("artists",artist):false;
                    // //update test
                    // bool t=artist!=null?dAL_DAO.update("artists","stage_name","assia",artist.ID):false;
                    // //delete test
                    // bool t=artist!=null?dAL_DAO.delete("artists",artist.ID):false;
                    // Console.WriteLine(t);
                    app.Run();

                }
    }
}

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllersWithViews();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();


