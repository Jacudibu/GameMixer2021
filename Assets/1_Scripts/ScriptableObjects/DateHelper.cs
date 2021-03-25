using System;
using System.Globalization;
using JetBrains.Annotations;

namespace ScriptableObjects
{
    public static class DateHelper
    {
        [NotNull] public static string GetTimestampString(int year, int month, int day, int hour, int minute)
        {
            return new DateTime(year, month, day, hour, minute, 0).ToString("g", CultureInfo.CurrentCulture);
        }
    }
}