namespace DrawGheterInfrastructure.Controllers.Dto;

public interface IBaseDto<out T>
{
    public T ToModel();
    public bool IsValid();
}