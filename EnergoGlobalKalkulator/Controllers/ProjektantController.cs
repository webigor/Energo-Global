using EnergoGlobalKalkulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnergoGlobalKalkulator.Controllers
{
    public class ProjektantController : Controller
    {
        //
        // GET: /Projektant/
        energo_globalEntities ent = new energo_globalEntities();



        Repositori r = new Repositori();




        public ActionResult Profil(int id)
        {
            Projektant novi = new Projektant();

            novi = r.vratiProjektanta(id);
            return View(novi);
        }

     
        

        public ActionResult Projekti(int id)
        {
            List<Projekat> zaProjektanta = r.vratiSveProjekte(id).ToList();
            ViewBag.Profil = id.ToString();
            int idMoj = 0;

            foreach (var item in zaProjektanta)
	        {
		     idMoj = (int)item.IdProjektant;
                break;

	        }

            ViewBag.IdProjekntant =idMoj ;
            return View(zaProjektanta);
           
          
        }


        public ActionResult Projekat(int id)
        {
           List<Korak> trazeni = r.vratiSveKorakeProjekta(id).ToList();

           ViewBag.Edit = id;

           decimal Start_A_ukupno = 0;
           decimal Start_KVA_ukupno = 0;
           decimal Start_KW_ukupno = 0;
           decimal Rad_KVA_ukupno = 0;
           decimal Rad_KW_ukupno = 0;
           decimal Rad_A_ukupno = 0;


           //zadnji korak

           Korak zadnji = new Korak();


           var showPiece = trazeni
                    .OrderByDescending(p => p.Korak1)
                    .FirstOrDefault();
           zadnji = showPiece;
           int kor = zadnji.Korak1;

           //zadnji korak

            //////////// Ako ima samo jedan korak

            if (kor == 1)
               {

                foreach (var item in trazeni)
	                {
		 
	

                   Start_A_ukupno += item.Start_A;


                   Start_KVA_ukupno += item.Start_KVA;


                   Start_KW_ukupno += item.Start_KW;



                   Rad_KVA_ukupno += item.Rad_KVA;



                   Rad_KW_ukupno += item.Rad_KW;


                   Rad_A_ukupno +=(decimal)item.Rad_A;

                   ViewBag.Start_A = Start_A_ukupno;
                   ViewBag.Start_KVA = Start_KVA_ukupno;
                   ViewBag.Start_KW = Start_KW_ukupno;
                   ViewBag.Rad_KVA = Rad_KVA_ukupno;
                   ViewBag.Rad_KW = Rad_KW_ukupno;
                   ViewBag.Rad_A = Rad_A_ukupno;
                   
               }
            }

              //////////// Ako ima samo jedan korak



             Start_A_ukupno = 0;
             Start_KVA_ukupno = 0;
             Start_KW_ukupno = 0;
             Rad_KVA_ukupno = 0;
             Rad_KW_ukupno = 0;
             Rad_A_ukupno = 0;
           // zbir zadnjih koraka starta plus n-1 rada

           if (kor >1)
	       {
		 
	       
            //////// //Lista minus zadnji korak 
           List<Korak> modifikovana = new List<Korak>();

           modifikovana = r.vratiSveKorakeProjekta(id).ToList(); 

           // zbir zadnjih korak Starta
           foreach (var item  in modifikovana.ToList())
           {
               if (item.Korak1 == kor)
               {
                   Start_A_ukupno += item.Start_A;


                   Start_KVA_ukupno += item.Start_KVA;


                   Start_KW_ukupno += item.Start_KW;
               }
           }
           // zbir zadnjih korak Starta


           // zbir zadnja  2 rada, zadnji N-1

           foreach (var item in modifikovana.ToList())
           {
               if (item.Korak1 == kor)
               {
                   modifikovana.Remove(item);
               }
           }


           foreach (var item in modifikovana.ToList())
           {

               Rad_KVA_ukupno += item.Rad_KVA;



               Rad_KW_ukupno += item.Rad_KW;


               Rad_A_ukupno += (decimal)item.Rad_A;
           }

           Start_A_ukupno += Rad_A_ukupno;
           Start_KVA_ukupno += Rad_KVA_ukupno;
           Start_KW_ukupno += Rad_KW_ukupno;



           // zbir zadnja  2 rada, zadnji N-1

           ///////Lista minus zadnji korak
          

          
         

          // Rad UKUOPNO
           Rad_A_ukupno = 0;
           Rad_KVA_ukupno = 0;
           Rad_KW_ukupno = 0;

           foreach (var item in trazeni)
           {

              


                  

              
               {
                   Rad_A_ukupno += (decimal)item.Rad_A;


                   Rad_KVA_ukupno += item.Rad_KVA;


                   Rad_KW_ukupno += item.Rad_KW;

                   //konacno dodavanje zbira n-1 kolona rada
                   //Start_A_ukupno += Rad_A_ukupno;
                   //Start_KVA_ukupno += Rad_KVA_ukupno;
                   //Start_KW_ukupno +=Rad_A_ukupno

                   //konacno dodavanje zbira n-1 kolona rada



                   ViewBag.Start_A = Start_A_ukupno;
                   ViewBag.Start_KVA = Start_KVA_ukupno;
                   ViewBag.Start_KW = Start_KW_ukupno;


                   ViewBag.Rad_KVA = Rad_KVA_ukupno;
                   ViewBag.Rad_KW = Rad_KW_ukupno;
                   ViewBag.Rad_A = Rad_A_ukupno;
               }

               // Kada imamo vise od jednog
                 }


               }

            return View(trazeni);
        }

        // Rad UKUOPNO

        //Kreiranje projekta
        public ActionResult Kreiraj_Projekat(int id)
        {

            Projekat novi = new Projekat();
            Projektant projektant = new Projektant();
            projektant = r.vratiProjektanta(id);



            if (projektant != null)
            {
                //var tipovi_potrosaca = r.vratiTipovePotrosaca().ToList();
                //ViewBag.TipoviPotrosaca = new SelectList(tipovi_potrosaca, "Id", "NazviKategorije", novi.Id);
                novi.IdProjektant = projektant.Id;
                novi.Datum_izrade = DateTime.Now.ToString("dd/MM/yyyy").ToString();
                novi.Ime_projektanta = projektant.Ime +  " "+ projektant.Prezime;
               
                return View(novi);
           
            }

            else
            {
                return RedirectToAction("Logovanje", "Registracija");
            }      

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Kreiraj_Projekat(Projekat ulaz)
        {
            try
            {

                r.DodajProjekat(ulaz);



                return RedirectToAction("Kreiraj_Korak", new { id = ulaz.Id });
            }
            catch (Exception ex)
            {
                string poruka = ex.Message;
                if (ex.InnerException != null)
                {
                    poruka += ex.InnerException.Message;
                }
                ViewBag.Greska = poruka;
                return View("slike");

            }
        }



        public ActionResult Izmena_projekta(int id)
        {
            Korak trazeni = r.vratiKorak(id);

            //Projekat projekat = new Projekat();
            //projekat = r.vratiProjekat(id);



            //ViewBag.NazivProjekta = projekat.Naziv_projekta;
            //ViewBag.Datum = projekat.Datum_izrade;
            //ViewBag.Projektant = projekat.Ime_projektanta;

            var tipovi_potrosaca = r.vratiTipovePotrosaca().ToList();
            ViewBag.TipoviPotrosaca = new SelectList(tipovi_potrosaca, "Id", "Tip_potrošaca", trazeni.IdTipPotrosaca);


            var broj_faza = r.vratiBrojFaza().ToList();

            ViewBag.BrojFaza = new SelectList(broj_faza, "Id", "Broj_faza", trazeni.IdBrojFaza);


            var start_motora = r.vratiStartMotora().ToList();

            ViewBag.StartMotora = new SelectList(start_motora, "Id", "Tip_starta_motora", trazeni.IdBrojFaza);

         



            return View(trazeni);
        }

        [HttpPost]
        public ActionResult Izmena_projekta(Korak ulaz)
        {

            Repositori r = new Repositori();

            r.IzmeniKorak(ulaz);


            return RedirectToAction("Projekat", "Projektant", new { id = ulaz.IdProjekat});
        }

        

        //Kreiranje koraka


        public ActionResult Kreiraj_Korak(int id)
        {

            Korak novi = new Korak();



           
            Projekat projekat = new Projekat();
            projekat = r.vratiProjekat(id);
         

        
            ViewBag.NazivProjekta = projekat.Naziv_projekta;
            ViewBag.Datum = projekat.Datum_izrade;
            ViewBag.Projektant = projekat.Ime_projektanta;


            
           
            



            if (projekat != null)
            {
                
             //Ovde vratiti partial view


              //novi.Projekat.Datum_izrade = novi2.Projekat.Datum_izrade;

              //novi.Projekat.Naziv_projekta = projekat.Naziv_projekta.ToString();
              //novi.Projekat.Ime_projektanta = projekat.Ime_projektanta.ToString();

              


              var tipovi_potrosaca = r.vratiTipovePotrosaca().ToList();
              ViewBag.TipoviPotrosaca = new SelectList(tipovi_potrosaca, "Id", "Tip_potrošaca", novi.IdTipPotrosaca);


              var broj_faza = r.vratiBrojFaza().ToList();

              ViewBag.BrojFaza = new SelectList(broj_faza, "Id", "Broj_faza", novi.IdBrojFaza);


              var start_motora = r.vratiStartMotora().ToList();

              ViewBag.StartMotora = new SelectList(start_motora, "Id", "Tip_starta_motora", novi.IdBrojFaza);

              novi.IdProjekat = projekat.Id;
              novi.Faktor = 1;

              return View(novi);

            }

            else
            {
                return RedirectToAction("Sledeci_korak", "Prokejktant");
            }

        }




        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Kreiraj_Korak(Korak ulaz,string np, string datum, string pro)
        {
            try
            {

                decimal koren3 = (decimal)(Math.Sqrt(3));
                decimal broj6 = (decimal)6.5;
                decimal broj2 = (decimal)2.2;

                // Opsta potrsonja

                if (ulaz.IdTipPotrosaca ==1)
                {

                    if (ulaz.IdBrojFaza == 1)
                    {
                        // formula Start A
                        ulaz.Start_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) /230;
                    }
                    else if( ulaz.IdBrojFaza ==2)
                    {
                       
                        // formula Start A
                        ulaz.Start_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / (koren3 * 400 * ulaz.URadu_P_F);
                    }
                   

                    // formula Start KVA
                    ulaz.Start_KVA = (ulaz.Snaga * ulaz.Kolicina) / ulaz.Start_P_F;

                    // fornula Start KW
                    ulaz.Start_KW = ulaz.Kolicina * ulaz.Snaga;

                    // formula Rad KVA
                    ulaz.Rad_KVA = (ulaz.Snaga * ulaz.Kolicina) / ulaz.URadu_P_F;

                    // formula Rad KW
                    ulaz.Rad_KW = ulaz.Kolicina * ulaz.Snaga;

                    // formula Rad A
                    if (ulaz.IdBrojFaza == 1)
                    {
                        // formula Start A
                        ulaz.Rad_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / 230;
                    }
                    else if (ulaz.IdBrojFaza == 2)
                    {
                       
                        // formula Start A
                        ulaz.Rad_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / (koren3 * 400 * ulaz.URadu_P_F);
                    }

                     
                }





             

                // za tip potrosaca motor

                if (ulaz.IdTipPotrosaca == 2) 
                {
                    //ako je broj faza 3
                    if (ulaz.IdBrojFaza == 2)
                    {

                    // START A
                    //Diretkan start
                    if (ulaz.IdStartMotora == 1)
                    {
                        ulaz.Start_A = (broj6 * 1000 * ulaz.Kolicina) /( koren3 * 400 * ulaz.Start_P_F);
                    }
                     //Wye Delta
                    if (ulaz.IdStartMotora == 2)
                    {
                        ulaz.Start_A = (broj2 * ulaz.Snaga * 1000 * ulaz.Kolicina) / ( koren3 * 400 * ulaz.Start_P_F);
                    }
                    // Frekventi konvetor
                    if (ulaz.IdStartMotora == 3)
                    {
                        ulaz.Start_A = (2 * ulaz.Snaga * 1000 * ulaz.Kolicina) / (koren3 * 400 * ulaz.Start_P_F);
                    }

                    //////////////////////////////////////////
                    // Fornula START KVA
                    //Diretkan start

                    if (ulaz.IdStartMotora == 1)
                    {
                        ulaz.Start_KVA = (broj6 * ulaz.Snaga * ulaz.Kolicina) / ulaz.Start_P_F;
                    }
                    //Wye Delta
                    if (ulaz.IdStartMotora == 2)
                    {
                        ulaz.Start_KVA = (broj2 * ulaz.Snaga * ulaz.Kolicina) / ulaz.Start_P_F;
                    }
                    // Frekventi konvetor

                    if (ulaz.IdStartMotora == 3)
                    {
                        ulaz.Start_KVA = (2 * ulaz.Snaga * ulaz.Kolicina) / ulaz.Start_P_F;
                    }

                    //////////////////////
                    //START KW
                    if (ulaz.IdStartMotora == 1)
                    {
                        ulaz.Start_KW = broj6 *ulaz.Kolicina * ulaz.Snaga;
                    }
                    //Wye Delta
                    if (ulaz.IdStartMotora == 2)
                    {
                        ulaz.Start_KW = broj2 * ulaz.Kolicina * ulaz.Snaga;
                    }
                    // Frekventi konvetor

                    if (ulaz.IdStartMotora == 3)
                    {
                        ulaz.Start_KW = 2 * ulaz.Snaga * ulaz.Kolicina;
                    }



                    // formula Rad A broj faza3
                    ulaz.Rad_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / (koren3 * 400 * ulaz.URadu_P_F);

                    //Rad kva
                    ulaz.Rad_KVA = (ulaz.Snaga * ulaz.Kolicina) / ulaz.URadu_P_F;

                    // formula Rad KW
                    ulaz.Rad_KW = ulaz.Kolicina * ulaz.Snaga;
                    
               


                    }




                    // Ako je broj faza 1 motor


                    if (ulaz.IdBrojFaza ==1)
                    {
                        // Ako je broj faza 1

                        // formula Start A
                        ulaz.Start_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / 230;

                        // formula Start KVA
                        ulaz.Start_KVA = (ulaz.Snaga * ulaz.Kolicina) / ulaz.Start_P_F;

                        // fornula Start KW
                        ulaz.Start_KW = ulaz.Kolicina * ulaz.Snaga;

                        // formula Rad KVA
                        ulaz.Rad_KVA = (ulaz.Snaga * ulaz.Kolicina) / ulaz.URadu_P_F;

                        // formula Rad A
                        ulaz.Rad_A = (ulaz.Snaga * 1000 * ulaz.Kolicina) / 230;

                        // formula Rad KW
                        ulaz.Rad_KW = ulaz.Kolicina * ulaz.Snaga;
                    }

                    


                }



                r.DodajKorak(ulaz);

                return RedirectToAction("Kreiraj_Korak", new { id = ulaz.IdProjekat, np = np, datum = datum, pro = pro });


                //if (Request.Form["submitbutton1"] != null)
                //{
                   
                //}
                //if (Request.Form["submitButton2"] != null)
                //{
                //    ulaz.Korak1 += 1;
                //    return RedirectToAction("Kreiraj_Korak", new { id = ulaz.IdProjekat, np = np, datum = datum, pro = pro });

                //}

                //return RedirectToAction("Kreiraj_Korak", new { id = ulaz.IdProjekat, np = np, datum = datum, pro = pro });

                 

              
            }
            catch (Exception ex)
            {
                string poruka = ex.Message;
                if (ex.InnerException != null)
                {
                    poruka += ex.InnerException.Message;
                }
                ViewBag.Greska = poruka;
                return View("slike");

            }
        }

        //Sledeci korak
        public ActionResult Sledeci_Korak(int id,string np, string datum, string pro)
        {

            List<Korak> trazeni = r.vratiSveKorakeProjekta(id).ToList();   

           

            Projekat projekat = new Projekat();
            projekat = r.vratiProjekat(id);

            ViewBag.NazivProjekta = np;
            ViewBag.Datum = datum;
            ViewBag.Projektant = pro;


            return PartialView("Sledeci_Korak", trazeni);
          

        

            

            

            //if (trazeni != null)
            //{

            //    var tipovi_potrosaca = r.vratiTipovePotrosaca().ToList();
            //    ViewBag.TipoviPotrosaca = new SelectList(tipovi_potrosaca, "Id", "Tip_potrošaca", novi.IdTipPotrosaca);


            //    var broj_faza = r.vratiBrojFaza().ToList();

            //    ViewBag.BrojFaza = new SelectList(broj_faza, "Id", "Broj_faza", novi.IdBrojFaza);


            //    var start_motora = r.vratiStartMotora().ToList();

            //    ViewBag.StartMotora = new SelectList(start_motora, "Id", "Tip_starta_motora", novi.IdBrojFaza);

            //    trazeni. = projekat.Id;
            //    novi.Faktor = 1;

            //    return View(novi);

            //}

            //else
            //{
            //    return RedirectToAction("Sledeci_korak", "Prokejktant");
            //}

        }





      


        

    }
}
