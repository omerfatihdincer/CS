using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Business.Shared.Abstract;
using CS.Business.Shared.Dto.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductController>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ILogger<ProductController> logger) : base(logger)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var list = _productService.GetProductList();
            return new JsonResult(list);
        }
    }
}