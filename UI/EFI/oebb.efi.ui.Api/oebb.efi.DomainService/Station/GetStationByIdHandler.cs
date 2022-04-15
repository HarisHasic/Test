using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;

namespace oebb.efi.Domain.Services.Station
{
    public class GetStationByIdHandler : IRequestHandler<GetStationByIdQuery, Models.Station>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStationByIdHandler> _logger;
        public IMediator _mediator;

        public GetStationByIdHandler(EfiContext efiContext, IMapper mapper, ILogger<GetStationByIdHandler> logger, IMediator mediator)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }
        public  async Task<Models.Station> Handle(GetStationByIdQuery request, CancellationToken cancellationToken)
        {

            //var result2 = await _mediator.Send(new GetStationQuery());
            //var output = result2.FirstOrDefault(x => x.Id == request._StationId);


           // var station = _context.Stations.Where(x => x.Id == request._StationId);

            var station = _context.Stations.Find(request._StationId);

            _logger.LogInformation($"Logger information is here");
            var result = Task.FromResult(_mapper.Map<Models.Station>(station));
            return await result;
        }
    }
}
