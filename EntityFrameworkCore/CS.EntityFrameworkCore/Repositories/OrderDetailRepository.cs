using CS.Core.DataAccess.EntityFramework;
using CS.Core.Order;
using CS.EntityFrameworkCore.Abstract;
using CS.EntityFrameworkCore.EntityFrameworkCore;

namespace CS.EntityFrameworkCore.Repositories
{
    public class OrderDetailRepository : EfEntityRepositoryBase<OrderDetail, CSDbContext>, IOrderDetailRepository
    {
    }
}
