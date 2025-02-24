namespace PutridParrot.FretPositions;

public record MultiScaleFretData(int Fret,
    string DisplayName,
    double BassDistanceFromNut, double BassDistanceFromPreviousFret,
    double TrebleDistanceFromNut, double TrebleDistanceFromPreviousFret,
    bool IsNeuralFret = false) :
    IFretData;