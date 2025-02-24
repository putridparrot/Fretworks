namespace PutridParrot.FretPositions;

/// <summary>
/// Specification for a multi-scale instrument
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Frets"></param>
/// <param name="NeutralFret"></param>
/// <param name="BassScaleLength"></param>
/// <param name="TrebleScaleLength"></param>
/// <param name="NutWidth"></param>
/// <param name="Units"></param>
/// <param name="Headless"></param>
public record MultiScaleInstrumentSpecification(int Id, string Name, int Frets, int NeutralFret,
    double BassScaleLength, double TrebleScaleLength,
    double NutWidth = -1,
    UnitsOfMeasurement Units = UnitsOfMeasurement.Millimetres,
    bool Headless = false) :
    IInstrumentSpecification;