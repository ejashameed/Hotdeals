using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hotdeals.API.common
{
    [ApiController]
    [Route("[controller]")]
    public class HotdealsBaseController: ControllerBase
    {
        public IMediator _mediator;
        
        public HotdealsBaseController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }    
    }
}
