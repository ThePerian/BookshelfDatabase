using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    public class WishlistRepo : BaseRepo<Wishlist>, IRepo<Wishlist>
    {
        public WishlistRepo()
        {
            Table = Context.Wishlist;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Wishlist()
            {
                BookId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Wishlist()
            {
                BookId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
