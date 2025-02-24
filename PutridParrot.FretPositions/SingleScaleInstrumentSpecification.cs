namespace PutridParrot.FretPositions;

/// <summary>
/// Specification for a single scale instrument
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Frets"></param>
/// <param name="ScaleLength"></param>
/// <param name="Units"></param>
/// <param name="NutWidth"></param>
/// <param name="Headless"></param>
public record SingleScaleInstrumentSpecification(int Id, string Name, int Frets, double ScaleLength,
    UnitsOfMeasurement Units = UnitsOfMeasurement.Millimetres,
    double NutWidth = -1,
    bool Headless = false) :
    IInstrumentSpecification;