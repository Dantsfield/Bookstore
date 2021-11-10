using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class SearchByBranchController : Controller
    {
        private BookstoreEntities db = new BookstoreEntities();
        // GET: SearchByBook
        public ActionResult Branch()
        {
            SearchByBook model = new SearchByBook();

            model.AllBranchLocations = db.BRANCHes.OrderBy(e => e.BRANCH_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.BRANCH_LOCATION,
                Value = s.BRANCH_NUM.ToString()
            });

            return PartialView("~/Views/Shared/_BranchLocation.cshtml", model);
        }
        public ActionResult Branch2()
        {
            SearchByBook model = new SearchByBook();

            model.AllBranchLocations = db.BRANCHes.OrderBy(e => e.BRANCH_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.BRANCH_NAME,
                Value = s.BRANCH_NUM.ToString()
            });

            return PartialView("~/Views/Shared/_BranchLocation2.cshtml", model);
        }
    }
}