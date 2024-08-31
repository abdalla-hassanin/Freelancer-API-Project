using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;

public class NotificationQueryHandler : ResponseHandler,
    IRequestHandler<GetNotificationsByClientIdQuery, Response<List<GetNotificationsResponse>>>,
        IRequestHandler<GetNotificationsByFreelancerIdQuery, Response<List<GetNotificationsResponse>>>
{   private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;


    public NotificationQueryHandler(IUnitOfWork unitOfWork,INotificationService notificationService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _unitOfWork=unitOfWork;
        _notificationService = notificationService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetNotificationsResponse>>> Handle(GetNotificationsByClientIdQuery request, CancellationToken cancellationToken)
    {
        var notifications =await _notificationService.GetByClientId(request.ClientId);
        if (notifications.Count == 0)
        {
            return Success(new List<GetNotificationsResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
            
        }
        foreach (var notification in notifications)
        {
            notification.IsRead = true;
        }
        await _unitOfWork.SaveAsync();
        var notificationsResponse = _mapper.Map<List<GetNotificationsResponse>>(notifications);

        return Success(notificationsResponse);
    }

    public async Task<Response<List<GetNotificationsResponse>>> Handle(GetNotificationsByFreelancerIdQuery request, CancellationToken cancellationToken)
    {
        var notifications =await _notificationService.GetByFreelancerId(request.FreelancerId);
        if (notifications.Count == 0)
        {
            return Success(new List<GetNotificationsResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
            
        }
        foreach (var notification in notifications)
        {
            notification.IsRead = true;
        }

        await _unitOfWork.SaveAsync();
        var notificationsResponse = _mapper.Map<List<GetNotificationsResponse>>(notifications);
        return Success(notificationsResponse);

    }
}