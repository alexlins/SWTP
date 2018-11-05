using Microsoft.Extensions.DependencyInjection;
using SWTP.Domain.DomainModels;
using SWTP.Domain.Interfaces.Repository;
using SWTP.Domain.Services;
using SWTP.Infra.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SWTP.Domain.Test
{
    public class StarShipDomainTest
    {
        private readonly StarShipDomain starShipDomain;
        private readonly IStarShipRepository _starShipRepository;

        public StarShipDomainTest()
        {

            //Setting up Dependency Injection
            var services = new ServiceCollection();
            services.AddTransient<IStarShipRepository, StarShipRepository>();
            var serviceProvider = services.BuildServiceProvider();
            _starShipRepository = serviceProvider.GetService<IStarShipRepository>();

            starShipDomain = new StarShipDomain(_starShipRepository);
        }


        [Fact]
        public void GetAllTest()
        {
            var result = starShipDomain.GetAll();

            Assert.NotNull(result);
        }



        [Theory]
        [InlineData("2hours", 2)]
        [InlineData("2days", 48)]
        [InlineData("2weeks", 336)]
        [InlineData("2months", 1440)]
        [InlineData("2years", 17520)]
        [InlineData("dummy", -1)]
        public void ConvertToHourRateTests(string param, long expected)
        {
            var actual = starShipDomain.ConvertToHourRate(param);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000000, "2 months", "75", 9)]
        [InlineData(1000000, "1 week", "80", 74)]
        [InlineData(1000000, "6 months", "20", 11)]
        public void CalculateStopsTests(long distance, string consumables, string MGLT, long expected)
        {
            var actual = starShipDomain.CalculateStops(distance, consumables, MGLT);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("https://swapi.co/api/starships/17/", 17)]
        [InlineData("https://swapi.co/api/starships/44/", 44)]
        [InlineData("https://swapi.co/api/starships/qeqwe/", -1)]
        public void GetStarShipCodeTests(string url, int expected)
        {
            var actual = starShipDomain.GetStarShipCode(url);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [ClassData(typeof(ListStarShipStopData))]
        public void GetAllStopsTest(long distance, IEnumerable<StarShipStopDomainModel> expected)
        {
            var actual = starShipDomain.GetAllStops(distance);

            Assert.NotEqual(expected, actual);
            Assert.Equal(expected.Count(), actual.Count());
        }



        

        

    }
    #region Mock Value
    public class ListStarShipStopData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1000000, ListStarShipStop };
        }

        private IEnumerable<StarShipStopDomainModel> ListStarShipStop = new[]
   {
            new StarShipStopDomainModel
            {
                StarShipCode = 31,
                Name = "Republic Cruiser",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 39,
                Name = "Naboo fighter",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 40,
                Name = "Naboo Royal Starship",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 41,
                Name = "Scimitar",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 43,
                Name = "J-type diplomatic barge",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 47,
                Name = "AA-9 Coruscant freighter",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 52,
                Name = "Republic Assault ship",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 48,
                Name = "Jedi starfighter",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 58,
                Name = "Solar Sailer",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 49,
                Name = "H-type Nubian yacht",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 63,
                Name = "Republic attack cruiser",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 64,
                Name = "Naboo star skiff",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 59,
                Name = "Trade Federation cruiser",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 65,
                Name = "Jedi Interceptor",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 61,
                Name = "Theta-class T-2c shuttle",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 77,
                Name = "T-70 X-wing fighter",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 74,
                Name = "Belbullab-22 starfighter",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 32,
                Name = "Droid control ship",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 75,
                Name = "V-wing",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 68,
                Name = "Banking clan frigate",
                Stops = -1,
                Message = "Information not available"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 15,
                Name = "Executor",
                Stops = 0,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 23,
                Name = "EF76 Nebulon-B escort frigate",
                Stops = 0,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 5,
                Name = "Sentinel-class landing craft",
                Stops = 19,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 27,
                Name = "Calamari Cruiser",
                Stops = 0,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 9,
                Name = "Death Star",
                Stops = 0,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 10,
                Name = "Millennium Falcon",
                Stops = 9,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 29,
                Name = "B-wing",
                Stops = 65,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 11,
                Name = "Y-wing",
                Stops = 74,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 12,
                Name = "X-wing",
                Stops = 59,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 13,
                Name = "TIE Advanced x1",
                Stops = 79,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 21,
                Name = "Slave 1",
                Stops = 19,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 22,
                Name = "Imperial shuttle",
                Stops = 13,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 3,
                Name = "Star Destroyer",
                Stops = 0,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 66,
                Name = "arc-170",
                Stops = 83,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 17,
                Name = "Rebel transport",
                Stops = 11,
                Message = "ok"
            },
            new StarShipStopDomainModel
            {
                StarShipCode = 2,
                Name = "CR90 corvette",
                Stops = 0,
                Message = "ok"
            }
        };

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    #endregion
}
