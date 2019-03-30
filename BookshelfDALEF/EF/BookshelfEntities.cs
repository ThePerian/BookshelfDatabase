namespace BookshelfDALEF.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using BookshelfDALEF.Models;

    public class BookshelfEntities : DbContext
    {
        static readonly DatabaseLogger DbLogger = new DatabaseLogger("F:\\sqllog.txt", true);

        public BookshelfEntities() : base("name=BookshelfConnection")
        {
            DbLogger.StartLogging();
            DbInterception.Add(DbLogger);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DbLogger);
            DbLogger.StopLogging();
            base.Dispose(disposing);
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