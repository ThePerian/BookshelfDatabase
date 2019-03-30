using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [Required]
        public bool ReadStatus { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
