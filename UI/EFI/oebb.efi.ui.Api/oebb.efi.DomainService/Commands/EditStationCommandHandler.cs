using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.Domain.Services.Commands
{
    public class EditStationCommandHandler : IRequestHandler<EditStationRequestCommand, StationEntity>
    {
        private readonly EfiContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EditStationCommandHandler> _logger;

        public EditStationCommandHandler(EfiContext efiContext, IMapper mapper, ILogger<EditStationCommandHandler> logger)
        {
            _context = efiContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StationEntity> Handle(EditStationRequestCommand request, CancellationToken cancellationToken)
        {

            var stations = request.Station;
            _logger.LogInformation($"loaded  Stations from database");
            var result = Task.FromResult(_mapper.Map<StationEntity>(stations));
            _context.Entry(stations).State = EntityState.Modified;
            _context.SaveChanges();
            return await result; 

        }
    }
}
