using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    class InventoryRepo : BaseRepo<Inventory>, IRepo<Inventory>
    {
        public InventoryRepo()
        {
            Table = Context.Inventory;
        }

        public int Delete(int id)
        {
            Context.Entry(new Inventory() { BookId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Inventory() { BookId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
