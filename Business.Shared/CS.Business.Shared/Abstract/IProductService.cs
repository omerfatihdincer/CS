using CS.Business.Shared.Dto.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Business.Shared.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductList();
    }
}
