using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oebb.efi.Domain.Services.Station
{
    public class GetStationByIdQuery: IRequest<Models.Station>
    {
        public long _StationId { get; set; }

        public GetStationByIdQuery(long StationId)
        {
            _StationId = StationId; 
        }
    }
}
