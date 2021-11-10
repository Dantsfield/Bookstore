using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class ContactPage
    {
        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; }
        [Required]
        public string comments { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string confirmEmail { get; set; }
        [Required]
        public string branch { get; set; }
    }
}