using DrawGheterInfrastructure.Controllers.Dto;
using DrawGheterInfrastructure.Repositories.Intefaces;
using DrawGheterInfrastructure.Services.Interfaces;

namespace DrawGheterInfrastructure.Services;

public class BaseService<TEntity, TCreateDto, TUpdateDto>(IBaseRepository<TEntity> repository)
    : IBaseService<TEntity, TCreateDto, TUpdateDto> where TCreateDto : IBaseDto<TEntity>
    where TUpdateDto : IBaseDto<TEntity>
{
    public TEntity? Show(int id)
    {
        return repository.Show(id);
    }

    public TEntity Create(TCreateDto dto)
    {
        return dto.IsValid()
            ? repository.Create(dto.ToModel())
            : throw new Exception("Invalid data, you passed:  " + dto);
    }

    public TEntity Update(TUpdateDto dto)
    {
        return dto.IsValid()
            ? repository.Update(dto.ToModel())
            : throw new Exception("Invalid data, you passed:  " + dto);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return repository.GetAll();
    }

    private static IEnumerable<TEntity> GetValidEntities<TDto>(IEnumerable<TDto> dtos) where TDto : IBaseDto<TEntity>
    {
        return dtos.Where(dto => dto.IsValid()).Select(dto => dto.ToModel());
    }

    public IEnumerable<TEntity> CreateRange(IEnumerable<TCreateDto> dtos)
    {
        return repository.CreateAll(GetValidEntities(dtos));
    }

    public IEnumerable<TEntity> UpdateRange(IEnumerable<TUpdateDto> dtos)
    {
        return repository.UpdateAll(GetValidEntities(dtos));
    }

    public void DeleteRange(IEnumerable<int> ids)
    {
        repository.DeleteAll(ids);
    }
}