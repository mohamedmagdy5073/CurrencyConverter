using Application.Shared.Dtos;
using Application.Shared.Helpers;
using Application.Shared.Interfaces;
using AutoMapper;
using Core.Shared;
using Core.Shared.Exceptions;

namespace Application.Shared
{
    public class Service<TEntity, TDto, TDetailsDto, TCreateDto, TUpdateDto> : IService<TEntity, TDto, TDetailsDto, TCreateDto, TUpdateDto> where TEntity : BaseEntity
                                                                                                                                            where TDto : BaseDto
                                                                                                                                            where TDetailsDto : BaseDto
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public virtual async Task<PagedResponse<TDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20)
        {
            var entities = await _repository.GetRangeAsync();

            if (entities is null)
                throw new NotFoundException("Not found entities!");

            var pagedList = await PagedList<TEntity>.ToPagedListAsync(entities, pageNumber, pageSize);
            return PreparePagedResponse(pagedList);
        }

        protected PagedResponse<TDto> PreparePagedResponse(PagedList<TEntity> pagedList)
        {
            return new()
            {
                TotalCount = pagedList.TotalCount,
                CountOfItems = pagedList.Count,
                PageNumber = pagedList.CurrentPage,
                PageSize = pagedList.PageSize,
                Items = _mapper.Map<List<TEntity>, List<TDto>>(pagedList)
            };
        }


        public virtual async Task<TDetailsDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                throw new NotFoundException("No entity by this id!");

            return _mapper.Map<TDetailsDto>(entity);
        }


        public virtual async Task<TDto> CreateAsync(TCreateDto entity)
        {
            var crearedEntity = await _repository.InsertAsync(_mapper.Map<TEntity>(entity));

            return _mapper.Map<TDto>(crearedEntity);
        }


        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                throw new NotFoundException("No entity by this id!");

            await _repository.DeleteAsync(entity);
        }


        public virtual async Task<TDto> UpdateAsync(Guid id, TUpdateDto entity)
        {
            var entityToUpdate = await _repository.GetByIdAsync(id);

            if (entityToUpdate is null)
                throw new NotFoundException("No entity by this id!");

            var updatedEntity = await _repository.UpdateAsync(_mapper.Map(entity, entityToUpdate));

            return _mapper.Map<TDto>(updatedEntity);
        }

    }
}
