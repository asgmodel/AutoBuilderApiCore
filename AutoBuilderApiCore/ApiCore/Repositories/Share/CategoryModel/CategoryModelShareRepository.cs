using ApiCore.DyModels.Dto.Build.Requests;
using ApiCore.DyModels.Dto.Build.Responses;
using ApiCore.DyModels.Dto.Share.Requests;
using ApiCore.DyModels.Dto.Share.Responses;
using ApiCore.Repositorys.Builder;
using AutoGenerator;
using AutoGenerator.Data;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using AutoGenerator.Repositorys.Base;
using AutoGenerator.Repositorys.Builder;
using AutoGenerator.Repositorys.Share;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiCore.Repositorys.Share
{
    /// <summary>
    /// CategoryModel class for ShareRepository.
    /// </summary>
    public class CategoryModelShareRepository : BaseShareRepository<CategoryModelRequestShareDto, CategoryModelResponseShareDto, CategoryModelRequestBuildDto, CategoryModelResponseBuildDto>, ICategoryModelShareRepository
    {
        // Declare the builder repository.
        private readonly CategoryModelBuilderRepository _builder;
        /// <1summary>
        /// Constructor for CategoryModelShareRepository.
        /// </summary>
        public CategoryModelShareRepository(DataContext dbContext, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            // Initialize the builder repository.
            _builder = new CategoryModelBuilderRepository(dbContext, mapper, logger.CreateLogger(typeof(CategoryModelShareRepository).FullName));
        // Initialize the logger.
        }

        /// <summary>
        /// Method to count the number of entities.
        /// </summary>
        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting CategoryModel entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for CategoryModel entities.");
                return Task.FromResult(0);
            }
        }

        /// <summary>
        /// Method to create a new entity asynchronously.
        /// </summary>
        public override async Task<CategoryModelResponseShareDto> CreateAsync(CategoryModelRequestShareDto entity)
        {
            try
            {
                _logger.LogInformation("Creating new CategoryModel entity...");
                // Call the create method in the builder repository.
                var result = await _builder.CreateAsync(entity);
                // Convert the result to ResponseShareDto type.
                var output = MapToShareResponseDto(result);
                _logger.LogInformation("Created CategoryModel entity successfully.");
                // Return the final result.
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating CategoryModel entity.");
                return null;
            }
        }

        /// <summary>
        /// Method to retrieve all entities.
        /// </summary>
        public override async Task<IEnumerable<CategoryModelResponseShareDto>> GetAllAsync()
        {


            TranslationData translation = new TranslationData
            {
                Value = new Dictionary<string, string>
            {
                { "en", "Category Name" },
                { "ar", "«”„ «·›∆…" },
                { "fr", "Nom de la catÈgorie" }
            }
            };

            // ≈‰‘«¡ ﬂ«∆‰ DTO ··›∆…
            CategoryModelResponseBuildDto category = new CategoryModelResponseBuildDto
            {
                Id = "123",
                Name = translation,
                Description = new TranslationData
                {
                    Value = new Dictionary<string, string>
                {
                    { "en", "This is a sample category" },
                    { "ar", "Â–Â ›∆…  Ã—Ì»Ì…" },
                    { "fr", "Ceci est une catÈgorie d'exemple" }
                }
                }
            };
           

            return  MapToIEnumerableShareResponseDto(new List<CategoryModelResponseBuildDto> { category });
            try
            {
                _logger.LogInformation("Retrieving all CategoryModel entities...");
                return MapToIEnumerableShareResponseDto(await _builder.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for CategoryModel entities.");
                return null;
            }
        }

        /// <summary>
        /// Method to get an entity by its unique ID.
        /// </summary>
        public override async Task<CategoryModelResponseShareDto?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving CategoryModel entity with ID: {id}...");
                return MapToShareResponseDto(await _builder.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for CategoryModel entity with ID: {id}.");
                return null;
            }
        }

        /// <summary>
        /// Method to retrieve data as an IQueryable object.
        /// </summary>
        public override IQueryable<CategoryModelResponseShareDto> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<CategoryModelResponseShareDto> for CategoryModel entities...");
                return MapToIEnumerableShareResponseDto(_builder.GetQueryable().ToList()).AsQueryable();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for CategoryModel entities.");
                return null;
            }
        }

        /// <summary>
        /// Method to save changes to the database.
        /// </summary>
        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for CategoryModel entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for CategoryModel entities.");
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Method to update a specific entity.
        /// </summary>
        public override async Task<CategoryModelResponseShareDto> UpdateAsync(CategoryModelRequestShareDto entity)
        {
            try
            {
                _logger.LogInformation("Updating CategoryModel entity...");
                return MapToShareResponseDto(await _builder.UpdateAsync(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for CategoryModel entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if CategoryModel exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("CategoryModel not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of CategoryModel with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<CategoryModelResponseShareDto>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all CategoryModels with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = MapToIEnumerableShareResponseDto(results.Data);
                return new PagedResponse<CategoryModelResponseShareDto>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all CategoryModels.");
                return new PagedResponse<CategoryModelResponseShareDto>(new List<CategoryModelResponseShareDto>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<CategoryModelResponseShareDto?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching CategoryModel by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("CategoryModel not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved CategoryModel successfully.");
                return MapToShareResponseDto(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving CategoryModel by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting CategoryModel with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("CategoryModel with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting CategoryModel with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<CategoryModelRequestShareDto> entities)
        {
            try
            {
                var builddtos = entities.OfType<CategoryModelRequestBuildDto>().ToList();
                _logger.LogInformation("Deleting {Count} CategoryModels...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} CategoryModels deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple CategoryModels.");
            }
        }
    }
}