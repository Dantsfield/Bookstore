using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class SearchByBookController : Controller
    {
        private BookstoreEntities db = new BookstoreEntities();
        // GET: SearchByBook
        public ActionResult Author()
        {
            SearchByBook model = new SearchByBook();

            model.AllBookOptions = db.AUTHORs.OrderBy(e => e.AUTHOR_LAST).ToList().Select(s => new SelectListItem
            {
                Text = s.AUTHOR_FIRST + " " + s.AUTHOR_LAST,
                Value = s.AUTHOR_NUM.ToString()
            });

            return PartialView("~/Views/Shared/_Author.cshtml", model);
        }

        public ActionResult Publisher()
        {
            SearchByBook model = new SearchByBook();

            model.AllBookOptions = db.PUBLISHERs.OrderBy(e => e.PUBLISHER_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.PUBLISHER_NAME,
                Value = s.PUBLISHER_CODE.ToString()
            });

            return PartialView("~/Views/Shared/_Publisher.cshtml", model);
        }


    }


}