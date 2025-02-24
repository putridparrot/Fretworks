namespace PutridParrot.FretPositions;

public class InstrumentSpecifications
{
    public Dictionary<string, IList<IInstrumentSpecification>?> Specifications { get; set; }
}

public static class DefaultInstrumentSpecifications
{
    private static IList<IInstrument> GetInstruments()
    {
        return new List<IInstrument>
            {
                new Instrument
                {
                    Name = "Guitar",
                    Id = 1,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        new SingleScaleInstrumentSpecification(1, "Classical Short", 20, 650, NutWidth: 50), // 650 mm
                        new SingleScaleInstrumentSpecification(2, "Classical Long", 20, 660, NutWidth: 51), // 660 mm
                        new SingleScaleInstrumentSpecification(3, "Fender Stratocaster Vintage (21 Fret)", 21, 647.7,
                            NutWidth: 42.8), // 25.500"
                        new SingleScaleInstrumentSpecification(4, "Fender Telecaster Vintage (21 Fret)", 21, 647.7,
                            NutWidth: 41.91), // 25.500"
                        new SingleScaleInstrumentSpecification(5, "Fender Stratocaster Modern (22 Fret)", 22, 647.7,
                            NutWidth: 42.8), // 25.500"
                        new SingleScaleInstrumentSpecification(6, "Fender Telecaster Modern (22 Fret)", 22, 647.7,
                            NutWidth: 41.91), // 25.500"
                        new SingleScaleInstrumentSpecification(7, "Fender Jaguar", 22, 609.6,
                            NutWidth: 41.3), // 24.000"
                        new SingleScaleInstrumentSpecification(8, "Fender Duosonic", 19, 571.5,
                            NutWidth: 42.0), // 22.500"
                        new SingleScaleInstrumentSpecification(9, "Fender Mustang", 19, 571.5,
                            NutWidth: 42.0), // 22.500"
                        new SingleScaleInstrumentSpecification(10, "Fender Baritone Telecaster", 24, 765.96748,
                            NutWidth: 41.3), // 30.1562"
                        new SingleScaleInstrumentSpecification(11, "Gibson Byrdland", 22, 596.9,
                            NutWidth: 43.0), // 23.500"
                        new SingleScaleInstrumentSpecification(12, "Gibson Long Scale (Acoustics)", 20,
                            642.62), // 	25.300"
                        new SingleScaleInstrumentSpecification(13, "Guild Acoustics (25 5/8\")", 20,
                            650.875), // 	25.625"
                        new SingleScaleInstrumentSpecification(14, "Guild Electrics (24 3/4\")", 21,
                            628.65), // 	24.750"
                        new SingleScaleInstrumentSpecification(15, "Guild Electrics (24 3/4\")", 22,
                            628.65), // 	24.750"
                        new SingleScaleInstrumentSpecification(16, "Martin Standard (25.5\")", 20,
                            647.7), // 	25.5" Dreadnought, OM
                        new SingleScaleInstrumentSpecification(17, "Martin Short (24.9\")", 20,
                            630.936), // 	24.840" O, OO, OOO
                        new SingleScaleInstrumentSpecification(18, "National", 20, 635), // 	25.000"
                        new SingleScaleInstrumentSpecification(19, "Paul Reed Smith (22 Fret)", 22, 635,
                            NutWidth: 43.0), // 	25.000"
                        new SingleScaleInstrumentSpecification(20, "Paul Reed Smith (24 Fret)", 24, 635,
                            NutWidth: 43.0), // 	25.000"
                        // Gibson guitars seem to vary through years, included all being 24 5/8" (625mm) or 24 9/16" (624mm)
                        new SingleScaleInstrumentSpecification(21, "Gibson SG", 24, 630, NutWidth: 41.0), // 	24.75"
                        new SingleScaleInstrumentSpecification(22, "Gibson Les Paul", 24, 630,
                            NutWidth: 43.0), // 	24.75"
                        new SingleScaleInstrumentSpecification(23, "Gibson Flying V", 24, 630,
                            NutWidth: 42.85), // 	24.75"
                        new SingleScaleInstrumentSpecification(24, "Gibson ES-225", 24, 630, NutWidth: 43.0), // 	24.75"
                        // multi scale
                        new MultiScaleInstrumentSpecification(25, "Strandberg Boden 6", 24, 0, 647.7, 635.0,
                            Headless: true), // 25.5", 25"
                        new MultiScaleInstrumentSpecification(26, "Strandberg Boden 7", 24, 7, 654.05, 635.0,
                            Headless: true), // 25.75", 25"
                        new MultiScaleInstrumentSpecification(27, "Strandberg Boden CL7", 24, 9, 666.75, 647.7,
                            Headless: true), // 26.25", 25.5"
                        new MultiScaleInstrumentSpecification(28, "Strandberg Boden 8", 24, 7, 711.2, 673.1,
                            Headless: true), // 28", 26.5"
                        new SingleScaleInstrumentSpecification(55, "Fender Jazzmaster", 21, 647.7,
                            NutWidth: 42.8), // 25.5"
                        new SingleScaleInstrumentSpecification(56, "Taylor GS Mini", 20, 596.9), // 23.5"
                        new SingleScaleInstrumentSpecification(57, "Martin LX1", 20, 584.2), // 23"
                        new SingleScaleInstrumentSpecification(58, "Ibanez JEM", 24, 647.7, NutWidth: 43.0), // 25.5"
                        new SingleScaleInstrumentSpecification(63, "Gibson Explorer", 22, 628.65,
                            NutWidth: 43.05), // 24.75"
                    }.OrderBy(id => id.Name).ToList()
                },
                new Instrument
                {
                    Name = "Bass",
                    Id = 2,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        // 30" (760mm) or less considered short scale
                        new SingleScaleInstrumentSpecification(29, "Fender Precision", 20, 863.6,
                            NutWidth: 41.3), // 34.000"
                        new SingleScaleInstrumentSpecification(71, "Fender Jazz", 20, 863.6, NutWidth: 38.1), // 34.000"
                        new SingleScaleInstrumentSpecification(30, "Fender Short scale", 20, 762), // 30.000"
                        new SingleScaleInstrumentSpecification(31, "Overwater P Series", 20, 863.6), // 34" or 35"
                        new SingleScaleInstrumentSpecification(32, "Wal Mk1", 21, 863.6, NutWidth: 42.0), // 34"
                        new SingleScaleInstrumentSpecification(33, "Wal Mk2", 24, 863.6, NutWidth: 42.0), // 34"
                        new SingleScaleInstrumentSpecification(70, "Wal Mk3", 24, 863.6), // 34"
                        new SingleScaleInstrumentSpecification(34, "Alembic Stanley Clarke", 24, 780.796), // 30.74"
                        new SingleScaleInstrumentSpecification(35, "Fodera Anthony Jackson Presentation", 28,
                            914.4), // 36"
                        new SingleScaleInstrumentSpecification(36, "Rickenbacker", 20, 844.55), // 33.25"
                        new SingleScaleInstrumentSpecification(59, "Gibson Thunderbird", 20, 863.6), // 34"
                        new SingleScaleInstrumentSpecification(60, "Gibson EB-3S", 20, 774.7), // 30.5"
                        new SingleScaleInstrumentSpecification(61, "Gibson EB-3L", 20, 863.6, NutWidth: 43.25), // 34"
                        new SingleScaleInstrumentSpecification(64, "Hofner 5001/Violin Bass", 20, 762), // 30"
                        new SingleScaleInstrumentSpecification(65, "Fodera Imperial MG", 26, 838.2), // 33"
                        new SingleScaleInstrumentSpecification(66, "Status S2", 24, 863.6, Headless: true), // 34"
                        new SingleScaleInstrumentSpecification(72, "Mayones Cali 4", 24, 436), // 16.7"
                        // need to confirm the parallel fret on the Dingwalls
                        new MultiScaleInstrumentSpecification(69, "Dingwall Super J 5-string", 22, 7, 889,
                            812.8), // 35", 32"
                        new MultiScaleInstrumentSpecification(67, "Dingwall ABZ 4", 24, 7, 920.75,
                            863.6), // 36.25", 34"
                        new MultiScaleInstrumentSpecification(68, "Dingwall ABZ 5", 24, 7, 939.8, 863.6), // 37", 34"
                        new MultiScaleInstrumentSpecification(69, "Dingwall ABZ 6", 24, 7, 939.8,
                            844.55), // 37", 33.25"
                    }.OrderBy(id => id.Name).ToList()
                },
                new Instrument
                {
                    Name = "Banjo",
                    Id = 3,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        new SingleScaleInstrumentSpecification(37, "Gibson (26 1/4\")", 22, 666.75), // 26.250"
                        new SingleScaleInstrumentSpecification(38, "Long neck (32 1/4\")", 25, 819.15), // 32.250"
                        new SingleScaleInstrumentSpecification(39, "Tenor (22 1/4\")", 19, 565.15), // 22.250"
                        new SingleScaleInstrumentSpecification(40, "Vega (27\")", 22, 685.8), // 27.000"
                    }.OrderBy(id => id.Name).ToList()
                },
                new Instrument
                {
                    Name = "Mandolin",
                    Id = 4,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        new SingleScaleInstrumentSpecification(41, "Gibson F5", 29, 352.425), // 	13.875"
                        new SingleScaleInstrumentSpecification(42, "Gibson A Model", 22, 358.775), // 	14.125"
                    }.OrderBy(id => id.Name).ToList()
                },
                new Instrument
                {
                    Name = "Dulcimer",
                    Id = 5,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        new SingleScaleInstrumentSpecification(43, "Short (25\")", 18, 635.0), // 	25-26"
                        new SingleScaleInstrumentSpecification(44, "Short (26\")", 18, 660.4), // 	25-26"
                        new SingleScaleInstrumentSpecification(45, "Standard (26.5\")", 18, 673.1), // 	26.5-27"
                        new SingleScaleInstrumentSpecification(46, "Standard (27 \")", 18, 685.8), // 26.5-27"
                        new SingleScaleInstrumentSpecification(47, "Long (28\")", 18, 711.2), // 	28-30"
                        new SingleScaleInstrumentSpecification(48, "Long (30 \")", 18, 762), // 28-30"
                    }.OrderBy(id => id.Name).ToList()
                },
                new Instrument
                {
                    Name = "Ukelele",
                    Id = 6,
                    Specifications = new List<IInstrumentSpecification>
                    {
                        // TODO: The scale lengths here are only the first, i.e. 13" but not the 14" for the first item and so on
                        new SingleScaleInstrumentSpecification(49, "Soprano", 12, 350), // 13.6"
                        new SingleScaleInstrumentSpecification(50, "Standard", 12, 330.2), // 13-14"
                        new SingleScaleInstrumentSpecification(51, "Concert", 18, 355.6), // 14-15"
                        new SingleScaleInstrumentSpecification(52, "Tenor", 18, 406.4), // 16-18"
                        new SingleScaleInstrumentSpecification(53, "Baritone", 19,
                            508), // 20-24" // check this wikipeda says 20.1"
                        new SingleScaleInstrumentSpecification(54, "Contrabass", 19, 508), // 20-21"
                    }.OrderBy(id => id.Name).ToList()
                }
            };
    }

    public static InstrumentSpecifications Get()
    {
        return new InstrumentSpecifications
        {
            Specifications = GetInstruments().ToDictionary(kv => kv.Name, kv => kv.Specifications)
        };
    }
}