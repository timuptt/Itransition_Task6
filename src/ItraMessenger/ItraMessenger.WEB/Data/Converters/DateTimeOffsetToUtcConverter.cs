using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItraMessenger.WEB.Data.Converters;

public class DateTimeOffsetToUtcConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetToUtcConverter() 
        : base(c => c.ToUniversalTime(), c => c) {}
}