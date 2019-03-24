using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    public partial class Wishlist
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(50)]
        public string Author { get; set; }
        
        [StringLength(50)]
        public string BookName { get; set; }

        public int StoreId { get; set; }
    }
}
