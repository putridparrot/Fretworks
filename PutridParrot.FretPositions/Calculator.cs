namespace PutridParrot.FretPositions;

public class Calculator
{
    private static readonly double FrequencyRatio = 1.0594631; // Math.Pow(2, 1 / 12.0);

    /// <summary>
    /// Calculates the fret positions on a single scale instrument
    /// </summary>
    /// <param name="numberOfFrets">The number of frets to calculate positions for</param>
    /// <param name="scaleLength">The scale length (this is unit agnostic)</param>
    /// <param name="numberOfDecimalPlaces">The number of decimal points to return</param>
    /// <param name="includeNut">Include the nut within the position information?</param>
    /// <param name="includeSaddles">Include the saddles/bridge within the position information?</param>
    /// <returns></returns>
    public List<SingleScaleFretData> Calculate(int numberOfFrets, double scaleLength, int numberOfDecimalPlaces = 3, bool includeNut = false, bool includeSaddles = false)
    {
        var results = new List<SingleScaleFretData>();

        if (includeNut)
        {
            results.Add(new SingleScaleFretData(
                0,
                "N",
                0,
                0));
        }

        var previous = 0.0;
        for (var fretNumber = 1; fretNumber <= numberOfFrets; fretNumber++)
        {
            var distance = scaleLength / Math.Pow(FrequencyRatio, fretNumber);
            var fretPositionFromNut = scaleLength - distance;
            var distancesFromPreviousFret = fretPositionFromNut - previous;
            results.Add(new(fretNumber,
                fretNumber.ToString(),
                Round(fretPositionFromNut, numberOfDecimalPlaces),
                Round(distancesFromPreviousFret, numberOfDecimalPlaces)));
            previous = fretPositionFromNut;
        }

        if (includeSaddles)
        {
            // single scale saddle positions
            results.Add(new SingleScaleFretData(
                0,
                "S",
                Round(scaleLength, numberOfDecimalPlaces),
                Round(scaleLength - previous, numberOfDecimalPlaces)));
        }

        return results;
    }

    /// <summary>
    /// Calculates the fret positions on a multi-scale instrument
    /// </summary>
    /// <param name="numberOfFrets">The number of frets to calculate positions for</param>
    /// <param name="bassScaleLength">The bass string scale length</param>
    /// <param name="trebleScaleLength">The treble string scale length</param>
    /// <param name="perpendicularFret">The perpendicular (also known as neutral or parallel fret) number</param>
    /// <param name="numberOfDecimalPlaces">The number of decimal points to return</param>
    /// <returns></returns>
    public List<MultiScaleFretData> Calculate(int numberOfFrets, double bassScaleLength,
        double trebleScaleLength, int perpendicularFret, int numberOfDecimalPlaces = 3)
    {
        var results = new List<MultiScaleFretData>();

        var fretCount = perpendicularFret > numberOfFrets ? perpendicularFret : numberOfFrets;

        var bass = CalculateRaw(fretCount, bassScaleLength);
        var treble = CalculateRaw(fretCount, trebleScaleLength);

        if (perpendicularFret <= 0)
        {
            // temp for initial testing
            results.Add(new MultiScaleFretData(
                0,
                "N",
                0,
                0,
                0,
                0,
                true));

            for (var i = 0; i < numberOfFrets; i++)
            {
                var bassData = bass[i];
                var trebleData = treble[i];
                results.Add(new MultiScaleFretData(
                    bassData.Fret,
                    bassData.Fret.ToString(),
                    Round(bassData.DistanceFromNut, numberOfDecimalPlaces),
                    Round(bassData.DistanceFromPreviousFret, numberOfDecimalPlaces),
                    Round(trebleData.DistanceFromNut, numberOfDecimalPlaces),
                    Round(trebleData.DistanceFromPreviousFret, numberOfDecimalPlaces)));
            }

            // add saddle position
            results.Add(new MultiScaleFretData(
                0,
                "S",
                Round(bassScaleLength, numberOfDecimalPlaces),
                Round(bassScaleLength - bass[^1].DistanceFromNut, numberOfDecimalPlaces),
                Round(trebleScaleLength, numberOfDecimalPlaces),
                Round(trebleScaleLength - treble[^1].DistanceFromNut, numberOfDecimalPlaces)));


            // include the nut and saddle values
            return results.Take(numberOfFrets + 2).ToList();
        }

        // TODO: ensure perpendicularFret < numberOfFrets
        var current = bass[perpendicularFret - 1].DistanceFromNut;
        for (var i = perpendicularFret - 1; i >= 0; i--)
        {
            var bassData = bass[i];
            var trebleData = treble[i];
            results.Add(new MultiScaleFretData(
                    bassData.Fret,
                    bassData.Fret.ToString(),
                    Round(bassData.DistanceFromNut, numberOfDecimalPlaces),
                    Round(bassData.DistanceFromPreviousFret, numberOfDecimalPlaces),
                    Round(current, numberOfDecimalPlaces),
                    Round(trebleData.DistanceFromPreviousFret, numberOfDecimalPlaces),
                    perpendicularFret == i + 1));

            current -= trebleData.DistanceFromPreviousFret;
        }

        // include nut
        results.Add(new MultiScaleFretData(
                0,
                "N",
                0,
                0,
                Round(current, numberOfDecimalPlaces),
                0));

        results = results.OrderBy(m => m.Fret).ToList();

        // now handle frets after perpendicular
        current = bass[perpendicularFret - 1].DistanceFromNut;
        for (var i = perpendicularFret; i < numberOfFrets; i++)
        {
            var bassData = bass[i];
            var trebleData = treble[i];

            current += trebleData.DistanceFromPreviousFret;

            results.Add(new MultiScaleFretData(
                    bassData.Fret,
                    bassData.Fret.ToString(),
                    Round(bassData.DistanceFromNut, numberOfDecimalPlaces),
                    Round(bassData.DistanceFromPreviousFret, numberOfDecimalPlaces),
                    Round(current, numberOfDecimalPlaces),
                    Round(trebleData.DistanceFromPreviousFret, numberOfDecimalPlaces)));
        }

        results = results.Take(numberOfFrets + 1).ToList();

        // add saddle position
        results.Add(new MultiScaleFretData(
                0,
                "S",
                Round(bassScaleLength, numberOfDecimalPlaces),
                Round(bassScaleLength - bass[^1].DistanceFromNut, numberOfDecimalPlaces),
                Round(trebleScaleLength, numberOfDecimalPlaces),
                Round(trebleScaleLength - treble[^1].DistanceFromNut, numberOfDecimalPlaces)));

        return results;
    }

    private static List<SingleScaleFretData> CalculateRaw(int numberOfFrets, double scaleLength)
    {
        var results = new List<SingleScaleFretData>();

        var previous = 0.0;
        for (var fretNumber = 1; fretNumber <= numberOfFrets; fretNumber++)
        {
            var distance = scaleLength / Math.Pow(FrequencyRatio, fretNumber);
            var fretPositionFromNut = scaleLength - distance;
            var distancesFromPreviousFret = fretPositionFromNut - previous;
            results.Add(new(fretNumber,
                fretNumber.ToString(),
                fretPositionFromNut,
                distancesFromPreviousFret));
            previous = fretPositionFromNut;
        }

        return results;
    }

    private static double Round(double value, int numberOfDecimalPlaces)
    {
        //var p = Math.Pow(10, numberOfDecimalPlaces);
        //return Math.Truncate(Math.Round(value, numberOfDecimalPlaces + 1) * p) / p;

        return Math.Round(value, numberOfDecimalPlaces);
    }
}