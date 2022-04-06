using MediatR;

namespace oebb.efi.Domain.Services.Station
{
    public class GetStationQuery : IRequest<IList<Models.Station>>
    {
    }
}
