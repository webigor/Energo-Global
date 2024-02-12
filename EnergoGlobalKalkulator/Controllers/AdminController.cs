using EnergoGlobalKalkulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnergoGlobalKalkulator.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Cms()
        
           
       
        {
            Repositori r = new Repositori();
            energo_globalEntities ent = new energo_globalEntities();

             Projektant novi = new Projektant();

             List<Projekat>  vratiSveProjekte =ent.Projekats.Include("Projektant").ToList();
                 
                 
                 //r.vratiSveProjekte().ToList();

             if (((Projektant)Session["projektant"]) != null)
                {
                    novi = (Projektant)Session["projektant"];
                }

               string email = novi.Email;

                if (novi.Email=="miodrag.sakic@energoglobal.com" && novi.Šifra=="20Miodrag23")
                {
                    return View(vratiSveProjekte);
                }

                if (novi.Email == "darko.reljic@energoglobal.com" && novi.Šifra == "darko2024")
                {
                    return View(vratiSveProjekte);
                }

                else 
                    if (!String.IsNullOrEmpty(email) && email.Contains("energoglobal"))
                {
                    //var nteList = ent.Projekats.Include("Projektant").Select(c => c.Projektant.Email).ToList();
                    //nteList.Any(nte => nte.Contains("energoglobal"));

                    List<Projekat> vratiSveProjekteEnergoProjekte = r.vratiSveProjekteEnergo().ToList();



                    return View("Zaposleni", vratiSveProjekteEnergoProjekte);
                
                }


                else
                {
                    return RedirectToAction("Registrovanje", "Registracija");
                }

     
        }

    }
}
