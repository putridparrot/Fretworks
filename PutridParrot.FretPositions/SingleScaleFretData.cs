namespace PutridParrot.FretPositions;

public record SingleScaleFretData(int Fret,
    string DisplayName,
    double DistanceFromNut, double DistanceFromPreviousFret) :
    IFretData;