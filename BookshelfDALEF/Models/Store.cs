using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    public partial class Store : EntityBase
    {
        [Key]
        public int StoreId { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(50)]
        public string URL { get; set; }

        [NotMapped]
        public string FullInfo => $"{ShortName} + ({URL})";

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
