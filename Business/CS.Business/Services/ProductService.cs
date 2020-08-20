using AutoMapper;
using CS.Business.Shared.Abstract;
using CS.Business.Shared.Dto.Product;
using CS.EntityFrameworkCore.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CS.Business.Services
{
    public class ProductService : BaseService<ProductService>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger) : base(mapper, logger)
        {
            _productRepository = productRepository;
        }



        public IEnumerable<ProductDto> GetProductList()
        {
            try
            {
                var productList = _productRepository.GetList(x => !x.IsDeleted);
                return _mapper.Map<IList<ProductDto>>(productList);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetProductListAsync Error", ex);
                throw ex;
            }
        }
    }
}
