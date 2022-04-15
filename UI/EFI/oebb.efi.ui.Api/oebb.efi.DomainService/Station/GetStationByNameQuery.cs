using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oebb.efi.Domain.Services.Station
{
    public record GetStationByNameQuery(string StationName) : IRequest<Models.Station>
    {
    }
}
