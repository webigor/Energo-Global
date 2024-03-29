//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnergoGlobalKalkulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Korak
    {
        public Korak()
        {
            this.ProjekatKorakUkupnoes = new HashSet<ProjekatKorakUkupno>();
        }
    
        public int Id { get; set; }
        public int IdProjekat { get; set; }
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)",ErrorMessage="Korak ne moze biti 0")]
        [Required(ErrorMessage = "Niste uneli  korak !")]
        [Display(Name = "Korak")]
        public int Korak1 { get; set; }

        [Required(ErrorMessage = "Niste uneli  opremu !")]
        public string Oprema { get; set; }

        [Required(ErrorMessage = "Niste uneli  Tip potro�a�a !")]
        [Display(Name = "Tip potro�a�a")]
        public int IdTipPotrosaca { get; set; }

        [Required(ErrorMessage = "Niste uneli  Broj faza !")]
        [Display(Name = "Broj faza")]
        public int IdBrojFaza { get; set; }

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Koli�ina ne moze biti 0")]
        [Required(ErrorMessage = "Niste uneli  koli�inu !")]
        [Display(Name = "Koli�ina")]
        public decimal Kolicina { get; set; }
        [Required(ErrorMessage = "Niste uneli  snagu !")]

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Snaga ne moze biti 0")]
        public decimal Snaga { get; set; }


        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Start P.F ne moze biti 0")]
        [Required(ErrorMessage = "Niste uneli  Start P.F !")]
        [Display(Name = "Start P.F")]
        public decimal Start_P_F { get; set; }

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "U radu P.F ne moze biti 0")]
        [Required(ErrorMessage = "Niste uneli  U radu P.F !")]
        [Display(Name = " U radu P.F")]
        public decimal URadu_P_F { get; set; }

        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Faktor ne moze biti 0")]
        [Required(ErrorMessage = "Niste uneli  faktor !")]
        public decimal Faktor { get; set; }

        [Display(Name = "Start motora")]
        public int IdStartMotora { get; set; }
        /// <summary>
        /// ///////////
        /// </summary>
        public decimal Start_A { get; set; }
        public decimal Start_KVA { get; set; }
        public decimal Start_KW { get; set; }
        public decimal Rad_KVA { get; set; }
        public decimal Rad_KW { get; set; }
        public Nullable<decimal> Rad_A{ get; set; }
    
        public virtual BrojFaza BrojFaza { get; set; }
        public virtual Projekat Projekat { get; set; }
        public virtual StartMotora StartMotora { get; set; }
        public virtual TipPotrosaca TipPotrosaca { get; set; }
        public virtual ICollection<ProjekatKorakUkupno> ProjekatKorakUkupnoes { get; set; }
    }
}
