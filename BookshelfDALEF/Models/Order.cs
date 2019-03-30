using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    public partial class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

        [ForeignKey("BookId")]
        public virtual Wishlist Book { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
