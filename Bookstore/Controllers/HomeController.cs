using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {

        private BookstoreEntities db = new BookstoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactPage model) 
        {
            if (String.IsNullOrEmpty(model.firstName))
            {
                ModelState.AddModelError("", "First Name Requried");
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult FormFilled(ContactPage model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

                RedirectToAction("Contact", model);
            }
            return Json(model);
        }



        public ActionResult AuthorBrowse(string id)
        {
            List<BOOK> books = new List<BOOK>();
            List<AUTHOR> authors = new List<AUTHOR>();
            if (String.IsNullOrEmpty(id))
            {

            }
            else
            {
                var allAuthors = db.AUTHORs.ToList();

                foreach (var author in allAuthors)
                {
                    BOOK bookModel = new BOOK();
                    AUTHOR model = new AUTHOR();
                    model.AUTHOR_NUM = author.AUTHOR_NUM;

                    var allBooks = from c in db.WROTEs
                                   where c.AUTHOR_NUM.ToString().Equals(id.ToString())
                                   select c.BOOK;

                    books = allBooks.ToList<BOOK>();
                }
            }
            return View(books);
        }

        public ActionResult LocationBrowse(string id)
        {
            List<BOOK> books = new List<BOOK>();
            List<BRANCH> branches = new List<BRANCH>();
            List<INVENTORY> inventory = new List<INVENTORY>();
            if (String.IsNullOrEmpty(id))
            {

            }
            else
            {

                var allBranches = db.BRANCHes.ToList();

                foreach (var branch in allBranches)
                {
                    BOOK bookModel = new BOOK();
                    BRANCH model = new BRANCH();
                    model.BRANCH_NUM = branch.BRANCH_NUM;

                    var selectedBranch = from c in db.BRANCHes
                                   where c.BRANCH_NUM.ToString().Equals(id.ToString())
                                   select c;

                    branches = selectedBranch.ToList();
                }


            }
            return View(branches);
        }

        public ActionResult BookDetails(string id)
        {
            BOOK book = db.BOOKs.Find(id);

            return View("~/Views/Home/BookDetails.cshtml", book);
        }
        //public ActionResult LocationBrowse()
        //{
        //    return View();
        //}
        public ActionResult PublisherBrowse(string id)
        {
            List<PUBLISHER> selectedPublisher = new List<PUBLISHER>();
            if (String.IsNullOrEmpty(id))
            {

            }
            else
            {
                var allPublishers = db.PUBLISHERs.ToList();

                foreach (var publisher in allPublishers)
                {
                    BOOK bookModel = new BOOK();
                    PUBLISHER model = new PUBLISHER();
                    model.PUBLISHER_CODE = publisher.PUBLISHER_CODE;

                    var allBooks = from c in db.PUBLISHERs
                                   where c.PUBLISHER_CODE.ToString().Equals(id.ToString())
                                   select c;

                    selectedPublisher = allBooks.ToList();
                }
            }
            return View(selectedPublisher);
        }
        public ActionResult InventoryBrowse()
        {
            var allBooks = db.BOOKs.ToList();
            List<BOOK> books = new List<BOOK>();

            foreach (var book in allBooks)
            {
                BOOK model = new BOOK();
                model.BOOK_CODE = book.BOOK_CODE;
                model.INVENTORies = db.INVENTORies.Where(a => a.BOOK_CODE == book.BOOK_CODE).ToList();
                books.Add(model);
            }

            return View(books);
        }
        public ActionResult NavBar()
        {
            return PartialView("~/Views/Shared/_Nav.cshtml");
        }
    }
}