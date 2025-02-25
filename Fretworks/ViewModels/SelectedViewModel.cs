namespace Fretworks.ViewModels;

public class SelectedViewModel
{
    public string? Instrument { get; set; }
    public string? MakeOrModel { get; set; }
    public int? NumberOfFrets { get; set; }
    public bool IsMultiScale { get; set; }
    public bool IsSingleScale => !IsMultiScale;
    public double? ScaleLength { get; set; }
    public double? BassScaleLength { get; set; }
    public double? TrebleScaleLength { get; set; }
    public int? NeutralFret { get; set; }
}