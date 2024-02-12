using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EnergoGlobalKalkulator.Models;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace EnergoGlobalKalkulator.Controllers
{
    public class RegistracijaController : Controller
    {
        //
        // GET: /Registracija/

        Repositori r = new Repositori();
        energo_globalEntities ent = new energo_globalEntities();

        public ActionResult Logovanje()
        {
            return View();

        }



        [HttpPost]
        public ActionResult Logovanje(Registrovanje model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (ent.Projektants.Any(r => r.Email == model.Email && r.Šifra == model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {

                        return Redirect(returnUrl);

                    }
                    else
                    {
                        Projektant moj = ent.Projektants.SingleOrDefault(r => r.Email == model.Email && r.Šifra == model.Password);

                        Session["projektant"] = moj;
                        //Session["projektant"] = DateTime.UtcNow.AddMinutes(35);

                        return RedirectToAction("Profil", "Projektant", new
                        {
                            id = moj.Id
                        });
                    }


                }
                else
                {
                    ModelState.AddModelError("", "Pogrešno korisničko ime ili šifra.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff()
        {
            Session["projektant"] = null;
            FormsAuthentication.SignOut();

            return RedirectToAction("Kalkulator", "EnergoGlobal");
           
        }

        public ActionResult Registrovanje()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrovanje(User korisnik)
        {
            

            //if (ModelState.IsValid)
            //{
           
            if (ent.Projektants.Any(r => r.Email == korisnik.Email))
            {
                ModelState.AddModelError("", "Već postoji korisnik registrovan pod tim emailom.");
            }

            else
            {
                try
                {
                    Projektant novi = new Projektant();

                    novi.Ime = korisnik.Ime;
                    novi.Prezime = korisnik.Prezime;
                    novi.Email = korisnik.Email;
                    novi.Šifra = korisnik.Šifra;
                    novi.Broj_telefona = korisnik.Broj_telefona;
                    novi.Kompanija = korisnik.Kompanija;
               

                

                    // Attempt to register the user


                    r.DodajKorisnika(novi);

                    Session["projektant"] = novi;
                    Session["projektant"] = DateTime.UtcNow.AddMinutes(35);

                    

                    FormsAuthentication.SetAuthCookie(novi.Ime, false /* createPersistentCookie */);



                    // odavde
                    //StringBuilder sb = new StringBuilder();
                    //MailMessage mail = new MailMessage();
                    //NetworkCredential cred = new NetworkCredential("loristshop@gmail.com", "Silmarilion1"); // odavde se salje


                    //mail.To.Add("loristdoo@gmail.com");
                    //mail.Subject = "Uspešna registracija";
                    //mail.From = new MailAddress("igorica22@hotmail.com");
                    //mail.IsBodyHtml = false;

                    //sb.Append("Poštovani, uspešno ste se registrovali.");
                    //sb.Append("\n");
                    //sb.Append("\n");
                    //sb.Append("Korisničko ime:" + novi.UserName);
                    //sb.Append("\n");
                    //sb.Append("\n");
                    //sb.Append("Šifra:" + novi.Sifra);

                    //mail.Body = sb.ToString();
                    //mail.ReplyTo = new MailAddress("loristdoo@gmail.com");

                    //SmtpClient smpt = new SmtpClient("smtp.gmail.com");
                    //smpt.UseDefaultCredentials = false;
                    //smpt.EnableSsl = true;
                    //smpt.Credentials = cred;
                    //smpt.Port = 587;
                    //smpt.Send(mail);


                    //mail.To.RemoveAt(0);

                    //mail.To.Add(novi.Email);
                    //mail.Subject = "Uspešna registracija";
                    //mail.From = new MailAddress("loristdoo@gmail.com");
                    //mail.IsBodyHtml = false;


                    //mail.Body = sb.ToString();
                    //mail.ReplyTo = new MailAddress("loristdoo@gmail.com");


                    //smpt.UseDefaultCredentials = false;
                    //smpt.EnableSsl = true;
                    //smpt.Credentials = cred;
                    //smpt.Port = 587;
                    //smpt.Send(mail);

                    // odavde


                    // String builder 2
                    //StringBuilder sb2 = new StringBuilder();
                    //sb2.Append("Zdravo Nanade, upravo se registrovao korisnik.");
                    //sb2.Append("\n");
                    //sb2.Append("\n");
                    //sb2.Append("Korisnicko ime:" + novi.UserName);


                    //SmtpClient smpt = new SmtpClient("mail.ribolovackaopremalorist.com");
                    //smpt.UseDefaultCredentials = false;
                    //smpt.EnableSsl = false;
                    //smpt.Credentials = cred;
                    //smpt.Port = 26;
                    //smpt.Send(mail);


                    //using (MailMessage mail = new MailMessage())
                    //{
                    //    mail.To.Add(novi.Email); // Korisnikov email
                    //    mail.Subject = "Lorist d.o.o registracija";
                    //    mail.Body = sb.ToString();
                    //    mail.IsBodyHtml = true;
                    //    mail.From = new MailAddress("office@ribolovackaopremalorist.com");
                    //    mail.ReplyTo = new MailAddress("office@ribolovackaopremalorist.com");

                    //    using (SmtpClient smtp = new SmtpClient("mail.ribolovackaopremalorist.com", 26))
                    //    {
                    //        smtp.Credentials = new NetworkCredential("office@ribolovackaopremalorist.com", "Mrena5kg");
                    //        smtp.EnableSsl = false;
                    //        smtp.Send(mail);
                    //    }
                    //}


                    //using (MailMessage mail = new MailMessage())
                    //{
                    //    mail.To.Add("loristdoo@gmail.com"); // anin email
                    //    mail.Subject = "Lorist registracija";
                    //    mail.Body = sb2.ToString();
                    //    mail.IsBodyHtml = true;
                    //    mail.From = new MailAddress("office@ribolovackaopremalorist.com");
                    //    //mail.ReplyTo = new MailAddress(novi.Email);


                    //    using (SmtpClient smtp = new SmtpClient("mail.ribolovackaopremalorist.com", 26))
                    //    {
                    //        smtp.Credentials = new NetworkCredential("office@ribolovackaopremalorist.com", "Mrena5kg");
                    //        smtp.EnableSsl = false;
                    //        smtp.Send(mail);
                    //    }
                    //}


                    //return RedirectToAction("Kalkulator", "EnergoGlobal");
                     return RedirectToAction("Profil", "Projektant", new
            {
                id = novi.Id
            });

                }

                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.
              PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                //}




            }
            return View(korisnik);
        }

    }
}
