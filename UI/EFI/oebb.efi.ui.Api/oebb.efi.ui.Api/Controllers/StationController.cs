using MediatR;
using Microsoft.AspNetCore.Mvc;
using oebb.efi.Domain.Models;
using oebb.efi.Domain.Services.Station;

namespace oebb.efi.ui.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public StationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "get")]
        public async Task<IList<Station>> Get()
        {
            return await _mediator.Send(new GetStationQuery());
        }
    }
}