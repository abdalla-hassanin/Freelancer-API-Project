using System.ComponentModel.DataAnnotations.Schema;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Queries;

public class GetClientResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime RegistrationTime { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    //TODO uncomment this when make GetJobResponse
 //   public List<GetJobResponse>? Jobs { get; set; } = [];

    // [NotMapped]
    // public int JobsCount => Jobs.Count;

    // [NotMapped]
    // public int CompletedJobsCount => Jobs.Count(j => j.Status == JobStatusEnum.Closed);
    //
}