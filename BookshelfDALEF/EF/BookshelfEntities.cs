namespace BookshelfDALEF.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using BookshelfDALEF.Models;

    public class BookshelfEntities : DbContext
    {
        //������� ������
        static readonly DatabaseLogger DbLogger = new DatabaseLogger("F:\\sqllog.txt", true);

        public BookshelfEntities() : base("name=BookshelfConnection")
        {
            //�������� ������ � ������ ������������� � ������ ������
            DbLogger.StartLogging();
            DbInterception.Add(DbLogger);
            //������������ ������������ - ������������ �������
            var context = (this as IObjectContextAdapter).ObjectContext;
            //����������, ����� ������ ���������������� �� ��������� ������
            context.ObjectMaterialized += OnObjectMaterialized;
            //����������, ����� ������ ������� ���������������� � ��������� ������
            context.SavingChanges += OnSavingChanges;
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DbLogger);
            DbLogger.StopLogging();
            base.Dispose(disposing);
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {

        }

        private void OnObjectMaterialized(object sender, 
            System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs eventArgs)
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