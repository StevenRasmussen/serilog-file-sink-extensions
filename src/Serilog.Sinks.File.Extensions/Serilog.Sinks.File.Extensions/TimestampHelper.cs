using System;
using System.Text.RegularExpressions;

namespace Serilog.Sinks.File.Extensions
{
    internal static class TimestampHelper
    {
        private static Regex _timeStampRegex = new Regex("{Timestamp:(.*?)}", RegexOptions.Compiled);
        public static string ReplaceTimestampTimeSlugs(string value, DateTime? dateTime = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            if (!value.Contains("{Timestamp"))
                return value;

            dateTime = dateTime ?? SystemTime.Now();

            var matches = _timeStampRegex.Matches(value);
            foreach (var match in matches)
            {
                var matchString = match.ToString()!;
                var dateTimeFormat = matchString.Replace("{Timestamp:", "").Replace("}", "");
                value = value.Replace(matchString, dateTime!.Value.ToString(dateTimeFormat));
            }
            return value;
        }
    }
}
