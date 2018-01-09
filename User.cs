using System;
using System.ComponentModel.DataAnnotations;

namespace MyDbConnection.Models
{
    public class User
    {
        public int id {get; set; }
        [Display(Name="First Name")]
        [Required(ErrorMessage="This Field is required")]
        public string first_name  {get; set; }
        [Display(Name="Last Name")]
        [Required(ErrorMessage="This Field is required")]
        public string last_name {get; set; }
        
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage="This Field is for email")]
        public string email {get; set; }
        
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="This Field is for Password")]

        public string password {get; set; }

        [Display(Name="Confirm")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="This Field is for Confirm")]
        [Compare("password", ErrorMessage="Password must match")]
         public string confirm {get; set;}


    }
}