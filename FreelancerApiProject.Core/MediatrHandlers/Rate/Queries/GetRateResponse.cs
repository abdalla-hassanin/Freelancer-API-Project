namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;

public class GetRateResponse
{
    public string? Feedback { get; set; }

    public int? Value { get; set; }

    public int JobId { get; set; }
}