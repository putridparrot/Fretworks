namespace PutridParrot.FretPositions;

/// <summary>
/// Definition of an instrument, i.e. it's a type of Name="Guitar" and
/// contains a collection of different guitar specifications
/// </summary>
public interface IInstrument
{
    string Name { get; set; }
    int Id { get; set; }
    IList<IInstrumentSpecification>? Specifications { get; set; }
}