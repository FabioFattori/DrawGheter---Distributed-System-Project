using DrawGheterInfrastructure.Controllers.Dto;

namespace DrawGheterInfrastructure.Services.Interfaces;

public interface IBaseService<out TEntity, in TCreateDto, in TUpdateDto> where TCreateDto : IBaseDto<TEntity>
    where TUpdateDto : IBaseDto<TEntity>
{
    public TEntity? Show(int id);
    public TEntity Create(TCreateDto dto);
    public TEntity Update(TUpdateDto dto);
    public void Delete(int id);
    public IEnumerable<TEntity> GetAll();
    public IEnumerable<TEntity> CreateRange(IEnumerable<TCreateDto> dtos);
    public IEnumerable<TEntity> UpdateRange(IEnumerable<TUpdateDto> dtos);
    public void DeleteRange(IEnumerable<int> ids);
}