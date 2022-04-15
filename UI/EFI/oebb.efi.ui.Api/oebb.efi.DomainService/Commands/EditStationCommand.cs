using MediatR;
using oebb.efi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oebb.efi.Domain.Services.Commands
{
   
    public record  EditStationCommand(StationEntity Station) : IRequest<StationEntity>
    {
    }
}
