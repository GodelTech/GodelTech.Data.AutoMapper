using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GodelTech.Data.AutoMapper.Tests.Fakes;
using AutoMapper;
using Xunit;

namespace GodelTech.Data.AutoMapper.Tests
{
    public class DataMapperTests
    {
        private readonly DataMapper _dataMapper;

        public DataMapperTests()
        {
            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<FakeSource, FakeDestination>()
                )
                .CreateMapper();

            _dataMapper = new DataMapper(mapper);
        }

        [Fact]
        public void Constructor()
        {
            // Arrange & Act & Assert
            Assert.IsAssignableFrom<IDataMapper>(_dataMapper);
        }


        public static IEnumerable<object[]> MapMemberData =>
            new Collection<object[]>
            {
                new object[] 
                {
                    new Collection<FakeSource>(),
                    new Collection<FakeDestination>()
                },
                new object[]
                {
                    new Collection<FakeSource>
                    {
                        new FakeSource
                        {
                            Id = 1,
                            Name = "Test Name",
                            SourceName = "Test SourceName"
                        }
                    },
                    new Collection<FakeDestination>
                    {
                        new FakeDestination
                        {
                            Id = 1,
                            Name = "Test Name",
                            DestinationName = null
                        }
                    }
                },
                new object[]
                {
                    new Collection<FakeSource>
                    {
                        new FakeSource
                        {
                            Id = 1,
                            Name = "Test First Name",
                            SourceName = "Test First SourceName"
                        },
                        new FakeSource
                        {
                            Id = 2,
                            Name = "Test Second Name",
                            SourceName = "Test Second SourceName"
                        },
                        new FakeSource
                        {
                            Id = 3,
                            Name = "Test Third Name",
                            SourceName = "Test Third SourceName"
                        }
                    },
                    new Collection<FakeDestination>
                    {
                        new FakeDestination
                        {
                            Id = 1,
                            Name = "Test First Name",
                            DestinationName = null
                        },
                        new FakeDestination
                        {
                            Id = 2,
                            Name = "Test Second Name",
                            DestinationName = null
                        },
                        new FakeDestination
                        {
                            Id = 3,
                            Name = "Test Third Name",
                            DestinationName = null
                        }
                    }
                }
            };

        [Theory]
        [MemberData(nameof(MapMemberData))]
        public void Map_Success(
            Collection<FakeSource> sourceList,
            Collection<FakeDestination> expectedResult)
        {
            // Arrange & Act
            var result = _dataMapper
                .Map<FakeDestination>(sourceList.AsQueryable())
                .ToList();

            // Assert
            Assert.Equal(expectedResult, result, new FakeDestinationEqualityComparer());
        }
    }
}