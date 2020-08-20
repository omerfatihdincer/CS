using CS.Core.DataAccess.EntityFramework;
using CS.Core.Order;
using CS.EntityFrameworkCore.Abstract;
using CS.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.EntityFrameworkCore.Repositories
{
    public class OrderRepository : EfEntityRepositoryBase<Order, CSDbContext>, IOrderRepository
    {
    }
}
