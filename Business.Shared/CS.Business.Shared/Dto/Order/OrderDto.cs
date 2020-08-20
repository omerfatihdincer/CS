using System;

namespace CS.Business.Shared.Dto.Order
{
    public class OrderDto: IEntityDto
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
    }
}
