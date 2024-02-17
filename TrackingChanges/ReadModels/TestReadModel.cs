namespace TrackingChanges.ReadModels;

public class TestReadModel : DocumentReadModel
{
    public string TestProperty { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} TestProperty: {TestProperty}";
    }
}