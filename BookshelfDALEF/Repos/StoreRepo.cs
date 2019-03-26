using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    class StoreRepo : BaseRepo<Store>, IRepo<Store>
    {
        public StoreRepo()
        {
            Table = Context.Stores;
        }

        public int Delete(int id)
        {
            Context.Entry(new Store() { StoreId = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Store() { StoreId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
