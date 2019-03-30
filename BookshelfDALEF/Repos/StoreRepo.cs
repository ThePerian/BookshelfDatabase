using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    public class StoreRepo : BaseRepo<Store>, IRepo<Store>
    {
        public StoreRepo()
        {
            Table = Context.Stores;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Store()
            {
                StoreId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Store()
            {
                StoreId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
