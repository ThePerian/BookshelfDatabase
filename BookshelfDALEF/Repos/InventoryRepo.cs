using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>, IRepo<Inventory>
    {
        public InventoryRepo()
        {
            Table = Context.Inventory;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Inventory()
            {
                BookId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Inventory()
            {
                BookId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
