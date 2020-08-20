using CS.Core.DataAccess.EntityFramework;
using CS.Core.Product;
using CS.EntityFrameworkCore.Abstract;
using CS.EntityFrameworkCore.EntityFrameworkCore;

namespace CS.EntityFrameworkCore.Repositories
{
    public class ProductRepository : EfEntityRepositoryBase<Product, CSDbContext>, IProductRepository
    {
    }
}
