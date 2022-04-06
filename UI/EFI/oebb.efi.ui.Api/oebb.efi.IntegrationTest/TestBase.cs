using AutoMapper;
using oebb.efi.Domain.Services;

namespace oebb.efi.IntegrationTest
{
    internal static class TestBase
    {
        internal static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
