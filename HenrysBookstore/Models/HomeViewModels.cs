using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}