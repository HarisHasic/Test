using AutoMapper;
using Entities = oebb.efi.DataAccess.Entities;
using DomainModels = oebb.efi.Domain.Models;

namespace oebb.efi.Domain.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.StationEntity, DomainModels.Station>();
        }        
    }
}
