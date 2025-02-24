using System.Text.Json.Serialization;

namespace PutridParrot.FretPositions;

[JsonPolymorphic]
[JsonDerivedType(typeof(SingleScaleInstrumentSpecification), typeDiscriminator: "singleScale")]
[JsonDerivedType(typeof(MultiScaleInstrumentSpecification), typeDiscriminator: "multiScale")]
public interface IInstrumentSpecification
{
    string Name { get; }
    int Id { get; }
    int Frets { get; }
    double NutWidth { get; }
    bool Headless { get; }
}