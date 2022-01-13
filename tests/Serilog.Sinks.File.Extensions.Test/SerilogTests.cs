using FluentAssertions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Serilog.Sinks.File.Extensions.Test
{
    [Collection(nameof(SerilogTestCollection))]
    public class SerilogTests
    {
        private readonly SerilogTestFixture _testFixture;
        public SerilogTests(SerilogTestFixture testFixture)
        {
            this._testFixture = testFixture;
            SystemTime.SetDateTime(new DateTime(2022, 01, 02, 3, 4, 5, 6, DateTimeKind.Unspecified));
        }

        [Fact]
        public async Task ReplaceTimestampSlugsLogger()
        {
            var logPathName = Path.Combine(this._testFixture.LoggingDirectory, "Log File With Date - {Timestamp:yyyy-MM-dd} Time {Timestamp:h_mm_ss.fff}.log");
            using (var logger = new LoggerConfiguration()
                  .WriteTo.FileWithTimestamp(
                      logPathName,
                      restrictedToMinimumLevel: Events.LogEventLevel.Verbose,
                      buffered: false,
                      flushToDiskInterval: TimeSpan.FromMilliseconds(100))
                  .CreateLogger())
            {
                logger.Information("Some Info");
            }

            await Task.Delay(2000);

            var expectedLogFileName = TimestampHelper.ReplaceTimestampTimeSlugs(logPathName);
            System.IO.File.Exists(expectedLogFileName).Should().BeTrue();
        }
    }
}
