public class NewOrder {
    public int UserId {get; set;}
    public required string Name {get; set;}
    public CustomType CustomType {get; set;}
    public string? Description {get; set;}
    public double? Price {get; set;}
}