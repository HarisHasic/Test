using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;

namespace oebb.efi.Domain.Services.Station
{
    public class GetStationQueryHandler : IRequestHandler<GetStationQuery, IList<Models.Station>>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStationQueryHandler> _logger;

        public GetStationQueryHandler(EfiContext efiContext, IMapper mapper, ILogger<GetStationQueryHandler> logger)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
        }
        public Task<IList<Models.Station>> Handle(GetStationQuery request, CancellationToken cancellationToken)
        {
            var stations = _context.Stations.AsNoTracking().ToList();            
            _logger.LogInformation($"loaded {stations.Count} Stations from database");
            var result = Task.FromResult(_mapper.Map<IList<Models.Station>>(stations));
            _logger.LogDebug("mapped entities to models");
            return result;
        }
    }
}
