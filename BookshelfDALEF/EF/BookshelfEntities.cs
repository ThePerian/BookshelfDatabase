namespace BookshelfDALEF.EF
{
    using System;
    using System.Data.Entity;
    using BookshelfDALEF.Models;

    public class BookshelfEntities : DbContext
    {
        public BookshelfEntities()
            : base("name=BookshelfConnection")
        {
        }

        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}