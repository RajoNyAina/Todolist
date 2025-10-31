using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TodolistApi.Data.Converters;

/// <summary>
/// Convertisseur des types DateTime pour respecter DateTimeKind = UTC.
/// </summary>
public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
    /// <summary>
    /// Initialise une instance de la classe <see cref="UtcDateTimeConverter"/>.
    /// </summary>
    public UtcDateTimeConverter() :
        base(
            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}