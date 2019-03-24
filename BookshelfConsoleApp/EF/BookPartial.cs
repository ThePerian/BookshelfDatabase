using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfConsoleApp.EF
{
    public partial class Book
    {
        public override string ToString()
        {
            return $"{this.BookId}: {this.Author} \"{this.BookName ?? "**Нет названия**"}\"";
        }
    }
}
