using AutoMapper;
using Microsoft.Extensions.Logging;

namespace CS.Business.Services
{
    
    public class BaseService<T>
    {
        public readonly ILogger<T> _logger;
        public readonly IMapper _mapper;
        public BaseService(IMapper mapper, ILogger<T> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
