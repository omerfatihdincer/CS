using CS.Business.Shared.Abstract;
using CS.Business.Services;
using CS.EntityFrameworkCore.Abstract;
using CS.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CS.WebAPI.Infrastructure
{
    public class IoC
    {
        private readonly IServiceCollection _services;
        public IoC(IServiceCollection services)
        {
            _services = services;
        }
        public void Register()
        {
            _services.AddTransient<IOrderService, OrderService>();
            _services.AddTransient<IProductService, ProductService>();
            _services.AddTransient<IOrderRepository, OrderRepository>();
            _services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            _services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
