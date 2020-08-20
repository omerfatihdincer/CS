using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Order
{
    public class OrderDetail : FullAuditedEntity, IEntity
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
