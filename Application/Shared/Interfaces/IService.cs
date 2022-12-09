using Application.Shared.Dtos;
using Core.Shared;

namespace Application.Shared.Interfaces
{
    public interface IService<TEntity, TDto, TDetailsDto, TCreateDto, TUpdateDto> where TEntity : BaseEntity
                                                                                  where TDto : BaseDto
                                                                                  where TDetailsDto : BaseDto
    {
        Task<PagedResponse<TDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20);
        Task<TDetailsDto> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto entity);
        Task DeleteAsync(Guid id);
        Task<TDto> UpdateAsync(Guid id, TUpdateDto entity);
    }
}
