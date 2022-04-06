using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using oebb.efi.DataAccess;
using oebb.efi.Domain.Services.Station;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace oebb.efi.IntegrationTest
{
    public class IntegrationTest
    {
        private readonly IMapper _mapper;
        private readonly EfiContext _efiContext;

        public IntegrationTest()
        {
            _mapper = TestBase.GetMapper();

            var dbName = $"EFI_Test_Db_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<EfiContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            _efiContext = new EfiContext(dbContextOptions);
        }
        [Fact]
        public async Task Station()
        {
            //Arrange
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 1, Shortcut = "W", Description = "Wien" });
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 2, Shortcut = "M", Description = "München" });
            _efiContext.SaveChanges();

            var handler = new GetStationQueryHandler(_efiContext, _mapper, new Mock<ILogger<GetStationQueryHandler>>().Object);

            //Act
            var result = await handler.Handle(new GetStationQuery(), CancellationToken.None);

            //Assert
            Assert.True(result.Count == 2);
        }
    }
}