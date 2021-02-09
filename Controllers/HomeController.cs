using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BookTracker.Models;

namespace BookTracker.Controllers
{
    /*
     * TODO: Store books in DB instead of Session.
     *   Use Html.DisplayFor() and the rest in Index view.
     *   Add update button functionality.
     */
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Book> books = DAL.BookTrackerStore.GetAllBooks(Session);

            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book newBook)
        {
            DAL.BookTrackerStore.AddBook(Session, newBook);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteBook(int index)
        {
            DAL.BookTrackerStore.DeleteBook(Session, index);

            return RedirectToAction("Index");
        }
    }
}