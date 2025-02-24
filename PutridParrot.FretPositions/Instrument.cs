namespace PutridParrot.FretPositions;

/// <summary>
/// Implementation of an IInstrument which defines instrument details,
/// i.e. it's a type of Name="Guitar" and contains a collection of
/// different guitar specifications
/// </summary>
public class Instrument : IInstrument
{
    public required string Name { get; set; }
    public required int Id { get; set; }
    public IList<IInstrumentSpecification>? Specifications { get; set; }
}