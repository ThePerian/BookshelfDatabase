namespace BookshelfConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        public int StoreId { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Store Store { get; set; }
    }
}
