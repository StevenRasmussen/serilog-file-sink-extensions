using FluentAssertions;
using System;
using Xunit;

namespace Serilog.Sinks.File.Extensions.Test
{
    public class TimestampHelperTests
    {
        public DateTime _currentDateTime = new DateTime(2022, 01, 02, 3, 4, 5, 6, DateTimeKind.Unspecified);

        [Theory()]
        [InlineData("Some Name {Timestamp:yyyy-MM-dd} Time {Timestamp:h:mm:ss.fff}", "Some Name 2022-01-02 Time 3:04:05.006")]
        public void DateSlugsReplacedCorrectly(string valueToTest, string expectedResult)
        {
            var result = TimestampHelper.ReplaceTimestampTimeSlugs(valueToTest, _currentDateTime);
            result.Should().Be(expectedResult);
        }
    }
}