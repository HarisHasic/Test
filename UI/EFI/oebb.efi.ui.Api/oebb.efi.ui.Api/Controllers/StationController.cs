using MediatR;
using Microsoft.AspNetCore.Mvc;
using oebb.efi.DataAccess.Entities;
using oebb.efi.Domain.Models;
using oebb.efi.Domain.Services.Commands;
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

        [HttpGet("{StationId}")]
        public async Task<IActionResult> Get(long StationId)
        {
            var Query = new GetStationByIdQuery(StationId);
            var result = await _mediator.Send(Query);
            if (result == null)
                return NotFound();
            else
                return Ok(result);

        }

        [HttpGet("GetByDescription/{StationName}")]
        public async Task<IActionResult> Get(string StationName)
        {
            var Query = new GetStationByNameQuery(StationName);
            var result = await _mediator.Send(Query);
            if (result == null)
                return NotFound();
            else
                return Ok(result);

        }
        [HttpPost]
        public async Task<StationEntity> CreateStation([FromBody]StationEntity command)
        {
            var model = new CreateStationRequestCommand(command);

            return  await _mediator.Send(model);
         

        }
    }
}