using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookTracker.Models;

namespace BookTracker.DAL
{
    public static class BookTrackerStore
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Title = "Test Book", Author = "Mr. Book", Read = true },
            new Book { Title = "Test Two", Author = "Mr. Book", Read = false },
        };

        public static List<Book> GetAllBooks(HttpSessionStateBase session)
        {
            if (!(session["books"] is List<Book> books))
            {
                books = new List<Book>(_books); // Consider: deep copy?
                session["books"] = books;
            }

            return books;
        }

        public static void AddBook(HttpSessionStateBase session, Book newBook)
        {
            List<Book> books = GetAllBooks(session);
            books.Add(newBook);
        }

        public static void DeleteBook(HttpSessionStateBase session, int index)
        {
            List<Book> books = GetAllBooks(session);
            books.RemoveAt(index);
        }
    }
}