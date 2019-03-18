using System;
using System.Collections.Generic;

namespace BookshelfDAL.Titles
{
    public class NewBook
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Read { get; set; }
    }
}
