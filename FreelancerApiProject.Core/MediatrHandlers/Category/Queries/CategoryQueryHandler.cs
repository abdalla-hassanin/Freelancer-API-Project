using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Queries;

public class CategoryQueryHandler:ResponseHandler,
    IRequestHandler<GetCategoriesQuery, Response<List<GetCategoryResponse>>>,
    IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryResponse>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public CategoryQueryHandler(ICategoryService categoryService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetCategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories =await _categoryService.GetAllAsync();
        if (categories.Count == 0)
        {
            return Success(new List<GetCategoryResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var categoriesResponse = _mapper.Map<List<GetCategoryResponse>>(categories);
        return Success(categoriesResponse);
    }

    public async Task<Response<GetCategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category =await _categoryService.GetByIdAsync(request.Id);
        if (category is null)
        {
            return Success(new GetCategoryResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var categoryResponse = _mapper.Map<GetCategoryResponse>(category);
        return Success(categoryResponse);
    }

}