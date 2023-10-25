using System.ComponentModel.DataAnnotations.Schema;

public class Order {
    [Column]
    public int Id {get; set;}
    [Column]
    public int UserId {get; set;}
    [Column]
    public required string Name {get; set;}
    [Column]
    public DateTime DateOfOrder {get; set;}
    [Column]
    public CustomType CustomType {get; set;}
    [Column]
    public string? Description {get; set;}
    [Column]
    public double? Price {get; set;}
    [Column]
    public StatusOrder StatusOrder {get; set;}
}