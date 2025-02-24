using PutridParrot.FretPositions;

namespace Fretworks.ViewModels;

/// <summary>
/// A view model representing the combination of the fields from single
/// and multi-scale instruments
/// </summary>
public class InstrumentViewModel(string name, int frets, double nutWidth, bool headless, UnitsOfMeasurement units, 
    double? scaleLength = null, int? neutralFret = null, double? bassScaleLength = null, double? trebleScaleLength = null)
{
    public string Name { get; } = name;
    public int Frets { get; } = frets;
    public double? ScaleLength { get; } = scaleLength;
    public double NutWidth { get; } = nutWidth;
    public bool Headless { get; } = headless;
    public string NutWidthString => NutWidth <= 0 ? "" : NutWidth.ToString();
    public bool IsMultiScale => BassScaleLength.HasValue && TrebleScaleLength.HasValue;
    public UnitsOfMeasurement Units { get; } = units;
    // multi-scale additions
    public int? NeutralFret { get; } = neutralFret;
    public double? BassScaleLength { get; } = bassScaleLength;
    public double? TrebleScaleLength { get; } = trebleScaleLength;
}
