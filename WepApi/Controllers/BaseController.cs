using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected IMapper Mapper =>
            _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
    }
}
