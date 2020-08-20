using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Business.Shared.Dto.Order
{
    public class OrderDetailDto
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
