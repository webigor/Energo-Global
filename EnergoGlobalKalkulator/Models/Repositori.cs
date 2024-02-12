using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergoGlobalKalkulator.Models
{
    public class Repositori
    {
        energo_globalEntities ent = new energo_globalEntities();
        public void DodajKorisnika(Projektant novi)
        {
            try
            {
                ent.Projektants.Add(novi);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Projektant VratiProjektanta(int id)
        {

            return ent.Projektants.SingleOrDefault(a => a.Id == id);

        }

        //vrati projektanta

        public Projektant vratiProjektanta(int id)
        {

            return ent.Projektants.Include("Projekats").SingleOrDefault(a => a.Id == id);     

        }


        //vrati projektanta

        public Projekat vratiProjekat(int id)
        {

            return ent.Projekats.Include("Projektant").SingleOrDefault(a => a.Id == id);

        }

        // dodaj projekat

        public void DodajProjekat(Projekat ulaz)
        {
            try
            {
                ent.Projekats.Add(ulaz);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // dodaj projekat

        public void DodajKorak(Korak ulaz)
        {
            try
            {
                ent.Koraks.Add(ulaz);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Izmena koraka
        public void IzmeniKorak(Korak ulaz)
        {
            Korak trenutni = ent.Koraks.SingleOrDefault(v => v.Id == ulaz.Id);

            trenutni.Korak1 = ulaz.Korak1;

            trenutni.Oprema = ulaz.Oprema;
            trenutni.IdTipPotrosaca = ulaz.IdTipPotrosaca;
            trenutni.IdBrojFaza = ulaz.IdBrojFaza;
            trenutni.Kolicina = ulaz.Kolicina;
            trenutni.Snaga = ulaz.Snaga;
            trenutni.Start_P_F = ulaz.Start_P_F;
            trenutni.URadu_P_F = ulaz.URadu_P_F;
            trenutni.Faktor = ulaz.Faktor;
            trenutni.IdStartMotora = ulaz.IdStartMotora;

            ent.SaveChanges();
        }

        //vrati projektanta

        public Korak vratiKorak(int id)
        {

            return ent.Koraks.Include("Projekat").SingleOrDefault(a => a.Id == id);

        }

        public List<Korak> vratiKorake(int id)
        {

            var koraci =  ent.Koraks.Include("Projekat").Where(a => a.Id == id);
            return koraci.ToList();
        }




        //Vrati tipove potrosaca
        public IQueryable<TipPotrosaca> vratiTipovePotrosaca()
        {
            try
            {
                var upit = from k in ent.TipPotrosacas
                           select k;
                return upit;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Broj faza


        
        //Vrati tipove potrosaca
        public IQueryable<BrojFaza> vratiBrojFaza()
        {
            try
            {
                var upit = from k in ent.BrojFazas
                           select k;
                return upit;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // Vrati start motora
        public IQueryable<StartMotora> vratiStartMotora()
        {
            try
            {
                var upit = from k in ent.StartMotoras
                           select k;
                return upit;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
   


       
        public IQueryable<Projekat> vratiSveProjekte(int id)
        {
            

            //var projekti = ent.Projekats.Include("Projektant").OrderByDescending(k => k.IdProjektant == id);
            var projekti = ent.Projekats.Include("Projektant").Where(k => k.IdProjektant == id);


            return projekti;


        }

        public IQueryable<Projekat> vratiSveProjekteEnergo()
        {

            
            //var projekti = ent.Projekats.Include("Projektant").OrderByDescending(k => k.IdProjektant == id);
            //  List<Visitor> visitors = te.Visitors.Include("Visits").ToList();

     

            //var projekti = ent.Projekats.Include("Projektant").Where(m => m.Projektant.Email.Any(energoglobal => m.Projektant.Email.Contains("energoglobal")));

            var projekti = ent.Projekats.Include("Projektant").Where(m => m.Projektant.Email.Contains("energoglobal"));

            return projekti;


        }


        // vrati sve admin MIlorad
        public IQueryable<Projekat> vratiSveProjekte()
        {


            var projekti = ent.Projekats.Include("Projekatant").Include("Projekat");



            return projekti;


        }



        public IQueryable<Korak> vratiSveKorakeProjekta(int id)
        {


            //var koraci = ent.Koraks.Include("Projekat").OrderByDescending(k => k.Id == id);


            var koraci = ent.Koraks.Include("Projekat").Where(k => k.IdProjekat == id).OrderBy(c => c.Korak1);

            
            return koraci;


        }


       

       

        //public IQueryable<Projektant> vratiProjektanta( int id)
        //{

          

        //    //var existingStudent = ent.Projektants.Include("Projekats").Include("Koraks");

        //    //return existingStudent;
        //}

    }
}