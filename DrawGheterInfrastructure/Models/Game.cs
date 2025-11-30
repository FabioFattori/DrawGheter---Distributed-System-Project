namespace DrawGheterInfrastructure.Models;

public class Game
{
    public required Guid Id { get; init; }
    public required Guid WinnerId { get; init; }
    public User? Winner  { get; init; }
    public required DateTime CreatedOn { get; init; }
    public DateTime? EndedOn { get; init; }
}