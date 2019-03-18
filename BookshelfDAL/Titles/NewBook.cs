using System;
using System.Collections.Generic;

namespace BookshelfDAL.Titles
{
    public class NewBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public bool ReadStatus { get; set; }
    }
}
