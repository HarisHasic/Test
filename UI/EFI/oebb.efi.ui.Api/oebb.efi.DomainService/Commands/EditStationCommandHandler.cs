using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using oebb.efi.DataAccess;
using oebb.efi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oebb.efi.Domain.Services.Commands
{
    public class EditStationCommandHandler:IRequestHandler<EditStationCommand, StationEntity>
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

        public async Task<StationEntity> Handle(EditStationCommand request, CancellationToken cancellationToken)
        {
            StationEntity a = request.Station;
           // db.Entry(ambalaza).State = EntityState.Modified;

            _context.Entry(a).State= EntityState.Modified;
            //_context.Stations.Update(request.StationID,a);
            _context.SaveChanges();


            _logger.LogInformation($"Logger information is here for edit or Put");

            var result = Task.FromResult((a));


            return await result ;

        }
    }
}
