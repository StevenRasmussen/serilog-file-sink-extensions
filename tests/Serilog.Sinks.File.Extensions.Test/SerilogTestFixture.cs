using System;
using System.IO;
using Xunit;

namespace Serilog.Sinks.File.Extensions.Test
{
    public class SerilogTestFixture
    {
        public SerilogTestFixture()
        {
            if (Directory.Exists(LoggingDirectory))
                Directory.Delete(LoggingDirectory, true);

            Directory.CreateDirectory(LoggingDirectory);
        }

        public string LoggingDirectory { get; } = "C:\\Temp\\TempLogFiles";
    }

    [CollectionDefinition(nameof(SerilogTestCollection))]
    public class SerilogTestCollection : ICollectionFixture<SerilogTestFixture>
    {
    }
}
