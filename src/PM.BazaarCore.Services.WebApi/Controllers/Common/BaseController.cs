using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PM.BazaarCore.Services.WebApi.Controllers.Common
{
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public BaseController(IMapper mapper, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _env = env;
        }

        public TOrigin Map<TOrigin>(object source) where TOrigin : class
        {
            return _mapper.Map<TOrigin>(source, c => c.Items["env"] = _env);
        }
    }
}
