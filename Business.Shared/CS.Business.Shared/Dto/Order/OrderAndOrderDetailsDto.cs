using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Business.Shared.Dto.Order
{
    public class OrderAndOrderDetailsDto
    {
        public OrderDto OrderDto { get; set; }
        public IEnumerable<OrderDetailDto> OrderDetailDtos { get; set; }
    }
}
