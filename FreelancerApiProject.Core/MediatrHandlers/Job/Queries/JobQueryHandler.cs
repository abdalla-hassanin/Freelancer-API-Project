using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries
{
    public class JobQueryHandler : ResponseHandler,
        IRequestHandler<GetJobsQuery, Response<List<GetJobResponse>>>,
        IRequestHandler<GetJobByIdQuery, Response<GetJobResponse>>,
        IRequestHandler<GetJobsByCategoryIdQuery, Response<List<GetJobResponse>>>,
        IRequestHandler<GetJobsByFreelancerIdQuery, Response<List<GetJobResponse>>>,
        IRequestHandler<GetJobsByClientIdQuery, Response<List<GetJobResponse>>>,
        IRequestHandler<GetJobsByTitleQuery, Response<List<GetJobResponse>>>,
        IRequestHandler<GetJobsPaginatedQuery, Response<PaginatedListModel<GetJobResponse>>>

    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public JobQueryHandler(IJobService jobService,
            IMapper mapper,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _jobService = jobService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobService.GetAllAsync();
            if (jobs.Count == 0)
            {
                return Success(new List<GetJobResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
            }

            var jobsResponse = _mapper.Map<List<GetJobResponse>>(jobs);
            return Success(jobsResponse);
        }

        public async Task<Response<GetJobResponse>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobService.GetByIdAsync(request.Id);
            if (job is null)
            {
                return Success(new GetJobResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
            }

            var jobResponse = _mapper.Map<GetJobResponse>(job);
            return Success(jobResponse);
        }

        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsByCategoryIdQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobService.GetAllByCategoryIdAsync(request.CategoryId);
            var jobsResponse = _mapper.Map<List<GetJobResponse>>(jobs);
            return Success(jobsResponse);
        }

        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsByFreelancerIdQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobService.GetAllByFreelancerIdAsync(request.FreelancerId);
            var jobsResponse = _mapper.Map<List<GetJobResponse>>(jobs);
            return Success(jobsResponse);
        }

        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsByClientIdQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobService.GetAllByClientIdAsync(request.ClientId);
            var jobsResponse = _mapper.Map<List<GetJobResponse>>(jobs);
            return Success(jobsResponse);
        }

        public async Task<Response<List<GetJobResponse>>> Handle(GetJobsByTitleQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobService.GetAllByTitleAsync(request.Title);
            var jobsResponse = _mapper.Map<List<GetJobResponse>>(jobs);
            return Success(jobsResponse);
        }

        public async Task<Response<PaginatedListModel<GetJobResponse>>> Handle(GetJobsPaginatedQuery request,
            CancellationToken cancellationToken)
        {
            var paginatedJobs = await _jobService.GetAllPaginatedAsync(request.PageNumber, request.PageSize);
            var paginatedJobsResponse = new PaginatedListModel<GetJobResponse>
            {
                Items = _mapper.Map<List<GetJobResponse>>(paginatedJobs.Items),
                TotalItems = paginatedJobs.TotalItems,
                TotalPages = paginatedJobs.TotalPages,
                CurrentPage = paginatedJobs.CurrentPage
            };
            return Success(paginatedJobsResponse);
        }
    }
}