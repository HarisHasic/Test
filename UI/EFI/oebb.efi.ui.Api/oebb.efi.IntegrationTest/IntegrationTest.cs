using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using oebb.efi.DataAccess;
using oebb.efi.Domain.Services.Commands;
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
        public IMediator medi;


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
        [Fact]
        public async Task StationById()
        {
            //Arrange
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 1, Shortcut = "W", Description = "Wien" });
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 2, Shortcut = "M", Description = "München" });
            _efiContext.SaveChanges();
            var finded = _efiContext.Stations.FirstOrDefaultAsync(x => x.Id == 2);
            var handler = new GetStationByIdHandler(_efiContext,_mapper, new Mock<ILogger<GetStationByIdHandler>>().Object,medi);

            //Act
            var result = await handler.Handle(new GetStationByIdQuery(2), CancellationToken.None);

            //Assert
            Assert.Equal("München", result.Description);
           // Assert.Equal(finded.Result.Id, result.Description);

         
        }
        [Fact]
        public async Task InsertStation()
        {
            //Arrange
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 1, Shortcut = "W", Description = "Wien" });
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 2, Shortcut = "M", Description = "München" });
            _efiContext.SaveChanges();
            DataAccess.Entities.StationEntity atest = new DataAccess.Entities.StationEntity
            { Id = 3, Shortcut = "K", Description = "Klagenfurt" };
            var handler = new CreaeStationCommandHandler(_efiContext, _mapper, new Mock<ILogger<CreaeStationCommandHandler>>().Object);
           
            //Act
            await handler.Handle(new CreateStationRequestCommand(atest), CancellationToken.None);
            var atest2 = _efiContext.Stations.FirstOrDefaultAsync(x=>x.Id==3);
            //Assert
            Assert.Equal("Klagenfurt", atest2.Result.Description) ;
            // Assert.Equal(finded.Result.Id, result.Description);

        }
        [Fact]
        public async Task EditStation()
        {
            //Arrange
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 1, Shortcut = "W", Description = "Wien" });
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 2, Shortcut = "M", Description = "München" });
            _efiContext.SaveChanges();
            DataAccess.Entities.StationEntity newStation = new DataAccess.Entities.StationEntity
            { Id = 3, Shortcut = "K", Description = "Klagenfurt" };
            _efiContext.Stations.Add(newStation);
            _efiContext.SaveChanges();
            newStation.Description = "KlagenfurtEdited";
            var handler = new EditStationCommandHandler(_efiContext, _mapper, new Mock<ILogger<EditStationCommandHandler>>().Object);

            //Act
            await handler.Handle(new EditStationRequestCommand(newStation), CancellationToken.None);
            var addedStation = _efiContext.Stations.FirstOrDefaultAsync(x => x.Id == 3);
            //Assert
            Assert.Equal("KlagenfurtEdited", addedStation.Result.Description);
            // Assert.Equal(finded.Result.Id, result.Description);

        }
        [Fact]
        public async Task DeleteStation()
        {
            //Arrange
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 1, Shortcut = "W", Description = "Wien" });
            _efiContext.Stations.Add(new DataAccess.Entities.StationEntity { Id = 2, Shortcut = "M", Description = "München" });
            _efiContext.SaveChanges();
           
          
            var handler = new DeleteStationCommandHandler(_efiContext, _mapper, new Mock<ILogger<DeleteStationCommandHandler>>().Object);

            //Act
            await handler.Handle(new DeleteStationRequestCommand(1), CancellationToken.None);
            
            //Assert
            Assert.Equal(1, _efiContext.Stations.CountAsync().Result);
         

        }
    }
}