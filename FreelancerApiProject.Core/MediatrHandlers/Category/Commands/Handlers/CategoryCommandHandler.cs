using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Handlers
{
    public class CategoryCommandHandler : ResponseHandler,
                                       IRequestHandler<AddCategoryCommand, Response<string>>
                                        ,IRequestHandler<EditCategoryCommand, Response<string>>
                                       ,IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public CategoryCommandHandler(ICategoryService categoryService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _categoryService= categoryService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryMapper = _mapper.Map<Data.Entities.Category>(request);
           
            var result = await _categoryService.CreateAsync(categoryMapper);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);
            if (category == null) return NotFound<string>("Category not found in database");
            
            // Update the Category's properties
            category.Title = request.Title ?? category.Title;
            category.Description = request.Description ?? category.Description;
            
            var result = await _categoryService.UpdateAsync(category);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }
        
        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);
            if (category == null) return NotFound<string>("Category not found in database");
            
            var result = await _categoryService.DeleteAsync(category);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
