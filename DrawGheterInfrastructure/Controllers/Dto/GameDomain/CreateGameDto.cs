using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto.GameDomain;

public class CreateGameDto : IBaseDto<Game>
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? EndedOn { get; set; }
    public Guid? WinnerId { get; init; }
    
    
    public Game ToModel()
    {
        return new Game
        {
            Id = Guid.Empty,
            CreatedOn = CreatedOn ?? DateTime.Now,
            EndedOn = EndedOn ?? null,
            Winner =  null,
            WinnerId = WinnerId ?? Guid.Empty
        };
    }

    public bool IsValid()
    {
        if (WinnerId is null && EndedOn is not null)
        {
            return false;
        }

        return !(EndedOn < CreatedOn);
    }
}