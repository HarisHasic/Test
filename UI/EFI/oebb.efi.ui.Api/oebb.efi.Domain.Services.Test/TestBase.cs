using AutoMapper;

namespace oebb.efi.Domain.Services.Test
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
