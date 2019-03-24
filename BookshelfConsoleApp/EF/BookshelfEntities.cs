namespace BookshelfConsoleApp.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookshelfEntities : DbContext
    {
        public BookshelfEntities()
            : base("name=BookshelfConnection")
        {
        }

        public virtual DbSet<Book> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);
        }
    }
}
