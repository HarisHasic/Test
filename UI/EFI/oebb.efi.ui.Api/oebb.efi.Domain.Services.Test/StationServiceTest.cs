using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using oebb.efi.DataAccess;
using oebb.efi.DataAccess.Entities;
using oebb.efi.Domain.Services.Station;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace oebb.efi.Domain.Services.Test
{
    public class StationServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<EfiContext> _efiContext;

        public StationServiceTest()
        {
            _mapper = TestBase.GetMapper();
            _efiContext = new Mock<EfiContext>();
        }

        [Fact]
        public async Task Test()
        {
            //Arrange
            var stations = new List<StationEntity>
            {
                new StationEntity { Id = 1, Shortcut = "W", Description = "Wien" },
                new StationEntity { Id = 2, Shortcut = "S", Description = "Salzburg" }
            };
            _efiContext.Setup(db => db.Stations).ReturnsDbSet(stations);
            var handler = new GetStationQueryHandler(_efiContext.Object, _mapper, new Mock<ILogger<GetStationQueryHandler>>().Object);

            //Act
            var result = await handler.Handle(new GetStationQuery(), CancellationToken.None);

            //Assert
            Assert.True(result.Count == 2);
            Assert.Equal(stations[0].Description, result[0].Description);
        }
    }
}