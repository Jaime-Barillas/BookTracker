using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTracker.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Read { get; set; }
    }
}