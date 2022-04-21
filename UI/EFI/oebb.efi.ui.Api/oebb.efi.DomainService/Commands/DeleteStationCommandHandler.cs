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
    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationRequestCommand, StationEntity>
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
        public async Task<StationEntity> Handle(DeleteStationRequestCommand request, CancellationToken cancellationToken)
        {
            var a=  _context.Stations.Find(request.StationId);
            var result = Task.FromResult(_mapper.Map<StationEntity>(a));
            if (a != null) { 
            _context.Stations.Remove(a);
            _context.SaveChanges();
            }
            return await result;
        }
    }
}
