namespace tests.model;

public class History
{
    public int Id { get; set; }
    public DateTime ConversionDate { get; set; } 
    public string? Source { get; set; }
    public string? Target { get; set; }
    public float Value { get; set; }
    public float Result { get; set; }
}