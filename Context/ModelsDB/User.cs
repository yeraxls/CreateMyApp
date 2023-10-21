using System.ComponentModel.DataAnnotations.Schema;

public class User {
    [Column]
    public int Id { get; set; }
    [Column]
    public required string Mail {get; set;}
    [Column]
    public required string Password {get; set;}
    [Column]
    public required string Name {get; set;}
}