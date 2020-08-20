using CS.Business.Shared.Dto.Order;
using CS.Core.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Business.Shared.Abstract
{
    public interface IOrderService
    {
        void AddOrderDetails(IList<OrderDetailDto> orderDetailDtos);
        IList<OrderDto> GetOrderList();
        IList<OrderDetailDto> GetOrderDetailListByOrderId(int id);
    }
}
