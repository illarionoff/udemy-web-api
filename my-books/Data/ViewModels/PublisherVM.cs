﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BooksAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
    }
}
