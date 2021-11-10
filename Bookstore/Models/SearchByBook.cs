using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Models
{
    public class SearchByBook
    {
        public string BookTitle { get; set; }

        public int AuthorCode { get; set; }
        public int AuthorSelected { get; set; }
        public string BookCode { get; set; } 
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<SelectListItem> AllBookOptions { get; set; }
        public IEnumerable<SelectListItem> AllBranchLocations { get; set; }
        public IEnumerable<SelectListItem> AllBooks { get; set; }
        public string BranchLocation { get; set; }

    }
}