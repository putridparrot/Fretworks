using System.Text.Json.Serialization;

namespace PutridParrot.FretPositions;

/// <summary>
/// Defines the preferred unit of measurements to use.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnitsOfMeasurement
{
    Millimetres,
    Inches
}