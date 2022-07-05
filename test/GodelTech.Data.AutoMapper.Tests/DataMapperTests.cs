using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using GodelTech.Data.AutoMapper.Tests.Fakes;
using Moq;
using Xunit;

namespace GodelTech.Data.AutoMapper.Tests
{
    public class DataMapperTests
    {
        private readonly Mock<IMapper> _mockMapper;

        private readonly DataMapper _dataMapper;

        public DataMapperTests()
        {
            _mockMapper = new Mock<IMapper>(MockBehavior.Strict);

            _dataMapper = new DataMapper(_mockMapper.Object);
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
                    new Collection<FakeSource>().AsQueryable(),
                    new Collection<FakeDestination>().AsQueryable()
                }
            };

        [Theory]
        [MemberData(nameof(MapMemberData))]
        public void Map_Success<TDestination>(
            IQueryable source,
            IQueryable<TDestination> expectedResult)
        {
            // Arrange
            _mockMapper
                .Setup(
                    x => x.ProjectTo(
                        source,
                        null,
                        Array.Empty<Expression<Func<TDestination, object>>>()
                    )
                )
                .Returns(expectedResult);

            // Act
            var result = _dataMapper
                .Map<TDestination>(source);

            // Assert
            _mockMapper
                .Verify(
                    x => x.ProjectTo(
                        source,
                        null,
                        Array.Empty<Expression<Func<TDestination, object>>>()
                    ),
                    Times.Once
                );

            Assert.Equal(expectedResult, result);
        }
    }
}
