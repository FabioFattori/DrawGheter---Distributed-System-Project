using DrawGheterInfrastructure.Models;

namespace DrawGheterInfrastructure.Controllers.Dto.GameDomain;

public class UpdateGameDto : IBaseDto<Game>
{
    public required Guid Id { get; set; }
    public required DateTime CreatedOn { get; set; }
    public required DateTime EndedOn { get; set; }
    public required Guid WinnerId { get; set; }


    public Game ToModel()
    {
        return new Game
        {
            Id = Id,
            CreatedOn = CreatedOn,
            EndedOn = EndedOn,
            WinnerId = WinnerId,
        };
    }

    public bool IsValid()
    {
        return !(EndedOn < CreatedOn);
    }
}