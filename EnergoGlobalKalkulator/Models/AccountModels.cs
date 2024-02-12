using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace EnergoGlobalKalkulator.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }




    public class AccountModels
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class Registrovanje
    {
        //[Required(ErrorMessageResourceName = "Niste uneli korisničko ime:")]
        [Required(ErrorMessage = "Niste uneli email !")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Niste uneli šifru !")]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Adresa { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


    [Bind(Exclude = "Id")]
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Niste uneli  ime !")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Niste uneli  preziime !")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Niste uneli email adresu !")]

        [RegularExpression(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", ErrorMessage = "Pogresan format email adrese")]
        [Display(Name = "Email")]
        public string Email { get; set; }

      

        [Required(ErrorMessage = "Niste uneli šifru !")]
        [StringLength(100, ErrorMessage = "Šifra  mora imati dužinu od najmanje {2} karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Šifra")]
        public string Šifra { get; set; }


       

        [Required(ErrorMessage = "Niste uneli telefon !")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Broj telefona")]
        public string Broj_telefona { get; set; }

        [Required(ErrorMessage = "Niste naziv kompanije !")]
        [DataType(DataType.Text)]
        [Display(Name = "Kompanija")]
        public string Kompanija { get; set; }

      
    }
}
