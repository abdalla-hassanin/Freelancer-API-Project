using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = "Freelancer,Client")]
public class NotificationController:AppControllerBase
{
    [HttpGet("FreelancerId/{id:int}")]
    [Authorize(Roles = "Freelancer")]
    public async Task<IActionResult> GetByFreelancerId([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetNotificationsByFreelancerIdQuery(id));
        return CreateResponse(response);
    }

    [HttpGet("ClientId/{id:int}")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetByClientId([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetNotificationsByClientIdQuery(id));
        return CreateResponse(response);
        
    }
}