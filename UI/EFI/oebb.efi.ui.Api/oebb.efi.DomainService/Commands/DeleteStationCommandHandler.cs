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
    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand, StationEntity>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStationCommandHandler> _logger;

        public DeleteStationCommandHandler(EfiContext efiContext, IMapper mapper, ILogger<DeleteStationCommandHandler> logger)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<StationEntity> Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            //Models.Station a = _mapper.Map<Models.Station>(request.Station);
            // db.Entry(ambalaza).State = EntityState.Modified;
            var station = _context.Stations.Find(request.Id);
            Task.FromResult(_context.Stations.Remove(station));
            _logger.LogInformation($"Logger information is here for delete");
            var result = Task.FromResult(_mapper.Map<StationEntity>(station));
            //_context.Stations.Update(request.StationID,a);
            _context.SaveChanges();

            return await result;
        }
    }
}
