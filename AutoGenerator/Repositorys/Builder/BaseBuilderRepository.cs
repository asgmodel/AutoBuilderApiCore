﻿
using AutoGenerator.Data;
using AutoGenerator.Repositorys.Base;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace AutoGenerator.Repositorys.Builder
{
    public interface IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBasePublicRepository<TBuildRequestDto, TBuildResponseDto>, ITBuildRepository
      where TBuildRequestDto : class
      where TBuildResponseDto : class
    {
        //   يمكن فقط اضافة الدوال العامه      المتعلقة بالطبقة   
        Task<IEnumerable<TBuildResponseDto>> GetAllAsync(Expression<Func<TBuildResponseDto, bool>>? filter = null, Func<IQueryable<TBuildResponseDto>, IQueryable<TBuildResponseDto>>? include = null, Expression<Func<TBuildResponseDto, object>>? order = null);

    }
    public abstract  class BaseBuilderRepository<TModel, TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto>,ITBuildRepository
      where TModel : class
      where TBuildRequestDto : class
      where TBuildResponseDto : class
    {

        protected readonly IBaseRepository<TModel> _repository;
        private readonly IMapper _mapper;
        protected readonly  ILogger _logger;
        public BaseBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger)
        {

            if (!IsAllowCreate())
            {
                throw new InvalidOperationException("Creation of this repository is not allowed for the specified types.");
            }

            _repository = new BaseRepository<TModel>(dbContext, logger);
            _mapper = mapper;
            _logger = logger;
           
        }

        #region Get Methods

        public async Task<IEnumerable<TBuildResponseDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(entity => _mapper.Map<TBuildResponseDto>(entity));
        }

        public async Task<TBuildResponseDto?> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByAsync(e => EF.Property<string>(e, "Id") == id);
            return entity != null ? _mapper.Map<TBuildResponseDto>(entity) : null;
        }

        public async Task<TBuildResponseDto?> FindAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {

            return null; 
        }

        public IQueryable<TBuildResponseDto> GetQueryable()
        {
            var entities = _repository.GetAll();
            return entities.Select(e => _mapper.Map<TBuildResponseDto>(e)).AsQueryable();
        }

        #endregion

        #region Create Methods

        public async Task<TBuildResponseDto> CreateAsync(TBuildRequestDto entity)
        {
            var modelEntity = _mapper.Map<TModel>(entity);
            modelEntity= await _repository.CreateAsync(modelEntity);
            return _mapper.Map<TBuildResponseDto>(modelEntity);
        }

        public async Task<IEnumerable<TBuildResponseDto>> CreateRangeAsync(IEnumerable<TBuildRequestDto> entities)
        {
            var modelModels = _mapper.Map<IEnumerable<TModel>>(entities);
            
            var listdto = new List<TBuildResponseDto>();
            foreach (var model in modelModels)
            {
              var bresp=  await _repository.CreateAsync(model);
                listdto.Add(_mapper.Map<TBuildResponseDto>(bresp));
            }
            return listdto;
        }

        #endregion

        #region Update Methods

        public async Task<TBuildResponseDto> UpdateAsync(TBuildRequestDto entity)
        {
            var modelEntity = _mapper.Map<TModel>(entity);
            modelEntity= await _repository.UpdateAsync(modelEntity);
            return _mapper.Map<TBuildResponseDto>(modelEntity);
        }

        #endregion

        #region Delete Methods

        public async Task DeleteAsync(string id)
        {
            await _repository.RemoveAsync(e => EF.Property<string>(e, "Id") == id);
        }

        //public async Task DeleteRangeAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        //{
        //    // حذف الكائنات بناءً على شرط معين
        //    await _repository.RemoveAsync(e => predicate.Invoke(_mapper.Map<TBuildResponseDto>(e)));
        //}

        //#endregion

        //#region Helper Methods

        //// التحقق إذا كان يوجد كائن يلبي الشرط المعطى
        //public async Task<bool> ExistsAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        //{
        //    var exists = await _repository.Exists(e => predicate.Invoke(_mapper.Map<TBuildResponseDto>(e)));
        //    return exists;
        //}

        public async Task<int> CountAsync()
        {
            // عد عدد العناصر في القاعدة
            return await _repository.GetAll().CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            // حفظ التغييرات في القاعدة
            await _repository.SaveAsync();
        }

        public Task DeleteRangeAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TBuildResponseDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion

        public async  Task<IEnumerable<TBuildResponseDto>> GetAllAsync(Expression<Func<TBuildResponseDto, bool>>? filter = null, Func<IQueryable<TBuildResponseDto>, IQueryable<TBuildResponseDto>>? include = null, Expression<Func<TBuildResponseDto, object>>? order = null)
        {
            var entities = await _repository.Get()
                .ProjectTo<TBuildResponseDto>(_mapper.ConfigurationProvider)
                .Where(filter)
                .ToListAsync();
            return entities;
        }

        private static bool IsAllowCreate()
        {
            return typeof(ITModel).IsAssignableFrom(typeof(TModel)) &&
                   typeof(ITBuildDto).IsAssignableFrom(typeof(TBuildResponseDto)) &&
                   typeof(ITBuildDto).IsAssignableFrom(typeof(TBuildRequestDto));
        }


        protected TBuildResponseDto MapToBuildResponseDto( TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The share response DTO cannot be null.");
            }

            return _mapper.Map<TBuildResponseDto>(model);
        }

        protected IEnumerable<TBuildResponseDto> MapToIEnumerableBuildResponseDto(IEnumerable<TModel> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models), "The share response DTO cannot be null.");
            }

            return _mapper.Map<IEnumerable<TBuildResponseDto>>(models);
        }



        protected TModel MapToBuildRequestDto(TBuildRequestDto  requestDto)
        {
            if (requestDto == null )
            {
                throw new ArgumentNullException(nameof(requestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<TModel>(requestDto);
        }


        protected IEnumerable<TModel> MapTIEnumerableBuildRequestDto(IEnumerable<TBuildRequestDto> requestDto)
        {
            if (requestDto == null)
            {
                throw new ArgumentNullException(nameof(requestDto), "The share request DTO cannot be null.");
            }

            return _mapper.Map<IEnumerable<TModel>>(requestDto);
        }



    }



}
