using System;
using System.Collections.Generic;
using CS.Core.Order;
using CS.Core.Product;
using CS.EntityFrameworkCore.EntityFrameworkCore;

namespace CS.EntityFrameworkCore.Seed
{
    public class DefaultDbCreator
    {
        private readonly CSDbContext _context;

        public DefaultDbCreator(CSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if (!_context.Database.CanConnect())
            {
                CreateDb();
                CreateProduct();
                CreateOrder();
                CreateOrderDetail();
            }

        }
        public void CreateDb()
        {
            _context.Database.EnsureCreated();
        }
        public void CreateProduct()
        {
            var list = new List<Product>{new Product{
                CategoryID = 1,
                Discontinued = false,
                ProductName = "Televizyon",
                QuantityPerUnit = 1,
                UnitPrice = 1000,
                UnitsInStock = 10,
                UnitsOnOrder = 5,
                CreationTime = DateTime.Now,
                IsDeleted = false
            },
                new Product{
                CategoryID = 1,
                Discontinued = false,
                ProductName = "Radyo",
                QuantityPerUnit = 1,
                UnitPrice = 100,
                UnitsInStock = 250,
                UnitsOnOrder = 100,
                CreationTime = DateTime.Now,
                IsDeleted = false
            },
                 new Product{
                CategoryID = 1,
                Discontinued = false,
                ProductName = "Mutfak Robotu",
                QuantityPerUnit = 1,
                UnitPrice = 300,
                UnitsInStock = 50,
                UnitsOnOrder = 20,
                CreationTime = DateTime.Now,
                IsDeleted = false
            }
            };

            _context.Products.AddRange(list);
        }

        public void CreateOrder()
        {
            //Order order = new Order
            //{
            //    OrderDate = DateTime.Now,
            //    RequiredDate = DateTime.Now.AddDays(1)
            //};

            //_context.Orders.Add(order);
        }

        public void CreateOrderDetail()
        {
            //OrderDetail orderDetail = new OrderDetail
            //{
            //    OrderID = 1,
            //    Discount = 1,
            //    ProductID = 1,
            //    Quantity = 3
            //};

            //_context.OrderDetails.Add(orderDetail);
        }

    }

}
