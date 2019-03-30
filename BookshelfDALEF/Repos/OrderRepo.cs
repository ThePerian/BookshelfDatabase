using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.Repos
{
    public class OrderRepo : BaseRepo<Order>, IRepo<Order>
    {
        public OrderRepo()
        {
            Table = Context.Orders;
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new Order()
            {
                OrderId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id, byte[] timeStamp)
        {
            Context.Entry(new Order()
            {
                OrderId = id,
                Timestamp = timeStamp
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
