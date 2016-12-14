using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HenrysBookstore.Models
{

    public class AuthorViewModel
    {
        public string authornum { get; set; }
    }

    public class PublisherViewModel
    {
        public string publishercode { get; set; }
    }

    public class LocationViewModel
    {
        public string branchnum { get; set; }
    }

    public class ContactManagementViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name ="Email")]
        public string EmailAddress { get; set; }

        [EmailAddress]
        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage ="The email addresses do not match")]
        public string ConfirmEmailAddress { get; set; }

        [Required]
        public string Branch { get; set; }
        [Required]
        public string Comments { get; set; }

    }
}
