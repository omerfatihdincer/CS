using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS.WebAPI.Controllers
{
   
    public class BaseController<T> : ControllerBase
    {
        public readonly ILogger<T> _logger;
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}