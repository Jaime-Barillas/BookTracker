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
     *   Move the NonAction methods below to some other place (Like a DB layer?).
     *   Use Html.DisplayFor() and the rest in Index view.
     *   Add update button functionality.
     */
    public class HomeController : Controller
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Title = "Test Book", Author = "Mr. Book", Read = true },
            new Book { Title = "Test Two", Author = "Mr. Book", Read = false },
        };

        [NonAction]
        private List<Book> GetAllBooks()
        {
            if (!(Session["books"] is List<Book> books))
            {
                books = _books;
                Session["books"] = _books;
            }

            return books;
        }

        [NonAction]
        private void AddANewBook(Book newBook)
        {
            List<Book> books = GetAllBooks();
            books.Add(newBook);
        }

        [NonAction]
        private void DeleteABook(int index)
        {
            List<Book> books = GetAllBooks();
            books.RemoveAt(index);
        }

        public ActionResult Index()
        {
            List<Book> books = GetAllBooks(); 

            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book newBook)
        {
            AddANewBook(newBook);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteBook(int index)
        {
            DeleteABook(index);

            return RedirectToAction("Index");
        }
    }
}