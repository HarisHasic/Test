using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using oebb.efi.DataAccess.Entities;

namespace oebb.efi.Domain.Services.Commands
{
    public record CreateStationRequestCommand(StationEntity _StationEntity) : IRequest<StationEntity>
    {
        //public StationEntity _StationEntity { get; set; }

        //public CreateStationRequestCommand(StationEntity stationEntity)
        //{
        //    _StationEntity = stationEntity;
        //}
    }
}
