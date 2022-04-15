using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oebb.efi.Domain.Services.Station
{
    public class GetStationByNameHandler: IRequestHandler<GetStationByNameQuery, Models.Station>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStationByNameHandler> _logger;
        public IMediator _mediator;

        public GetStationByNameHandler(EfiContext efiContext, IMapper mapper, ILogger<GetStationByNameHandler> logger, IMediator mediator)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<Models.Station> Handle(GetStationByNameQuery request, CancellationToken cancellationToken)
        {
            var station = _context.Stations.FirstOrDefault(x=>x.Description==request.StationName);

            _logger.LogInformation($"Trying to figur out what a logger dose");
            var result = Task.FromResult(_mapper.Map<Models.Station>(station));
            return await result;
        }
    }
}
