namespace Fretworks.ViewModels;

public class FretPositionsViewModel
{
    public int Fret { get; set; }
    public bool Done { get; set; }

    // Single scale
    public double DistFromNut { get; set; }
    public double DistPrevFret { get; set; }

    // Multi-scale
    public double BassDistFromNut { get; set; }
    public double BassDistPrevFret { get; set; }
    public double TrebleDistFromNut { get; set; }
    public double TrebleDistPrevFret { get; set; }
}