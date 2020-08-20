using AutoMapper;
using CS.Business.Shared.Abstract;
using CS.Business.Shared.Dto.Order;
using CS.Core.Order;
using CS.Core.Product;
using CS.EntityFrameworkCore.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Business.Services
{

    public class OrderService : BaseService<OrderService>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository, IMapper mapper, ILogger<OrderService> logger) : base(mapper, logger)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }


        /// <summary>
        /// Sepete Ürün Ekler 
        /// </summary>
        /// <param name="orderDetailDtos"></param>
        public void AddOrderDetails(IList<OrderDetailDto> orderDetailDtos)
        {
            try
            {
                if (!orderDetailDtos.Any())
                {
                    return;
                }

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddHours(1),
                    IsDeleted = false,
                    CreationTime = DateTime.Now
                };
                _orderRepository.Add(order);

                var products = _productRepository.GetList(x => !x.IsDeleted);

                foreach (var item in orderDetailDtos)
                {
                    if (ControlStock(products, item.ProductID, item.Quantity))
                    {
                        var orderDetail = _mapper.Map<OrderDetail>(item);
                        orderDetail.OrderID = order.OrderID;
                        orderDetail.CreationTime = DateTime.Now;
                        orderDetail.IsDeleted = false;

                        _orderDetailRepository.Add(orderDetail);
                    }                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("AddOrderDetails Error", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Sepeti Listeler
        /// </summary>
        /// <returns></returns>
        public IList<OrderDto> GetOrderList()
        {
            try
            {
                var result = _orderRepository.GetList(x => !x.IsDeleted);
                return _mapper.Map<IList<OrderDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetOrderList Error", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Sepet Detayını Listeler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<OrderDetailDto> GetOrderDetailListByOrderId(int id)
        {
            try
            {
                var result = _orderDetailRepository.GetList(x => !x.IsDeleted && x.OrderID == id);
                return _mapper.Map<IList<OrderDetailDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetOrderList Error", ex);
                throw ex;
            }
        }

        private bool ControlStock(IList<Product> products, int productId, int quantity)
        {
            var product = products.FirstOrDefault(x => x.ProductID == productId);
            var currentStock = product.UnitsInStock - product.UnitsOnOrder;
            return currentStock >= quantity;
        }
    }
}
