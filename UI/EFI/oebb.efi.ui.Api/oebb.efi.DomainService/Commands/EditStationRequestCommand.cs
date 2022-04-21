using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.Domain.Services.Commands
{
    public record EditStationRequestCommand(StationEntity Station): IRequest<StationEntity>
    {
    }
}
