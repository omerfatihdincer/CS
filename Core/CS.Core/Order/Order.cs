using CS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Order
{
    public class Order : FullAuditedEntity, IEntity
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
    }
}
