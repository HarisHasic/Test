using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.Domain.Services.Commands
{
    public class CreaeStationCommandHandler : IRequestHandler<CreateStationRequestCommand, StationEntity>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreaeStationCommandHandler> _logger;

        public CreaeStationCommandHandler(EfiContext efiContext, IMapper mapper, ILogger<CreaeStationCommandHandler> logger)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
        }
         
        public  async Task<StationEntity> Handle(CreateStationRequestCommand request, CancellationToken cancellationToken)
        {
            //_context.Stations.Add(new StationEntity { Id = request.Id, SearchTerm = request.SearchTerm, Description = request.Description, Shortcut = request.Shortcut });
            //_context.SaveChanges();
            //return null;
            Models.Station a = _mapper.Map<Models.Station>(request._StationEntity);
          
            _context.Stations.Add(request._StationEntity);
            _context.SaveChanges();
     
            return null;


            //   _logger.LogInformation($"loaded {stations.Count} Stations from database");

        }
    }
}
