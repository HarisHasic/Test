using AutoMapper;
using Xunit;

namespace oebb.efi.Domain.Services.Tests.Mapping
{
    public class MapConfigurationTest
    {
        [Fact]
        public void AutoMapperConfigurationIsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            
          //  var config = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
          
         
            config.AssertConfigurationIsValid();
        }
    }
}
