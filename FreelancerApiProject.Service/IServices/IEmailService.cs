using FreelancerApiProject.Service.DTO;

namespace FreelancerApiProject.Service.IServices
{
    public interface IEmailService
    {
        Task SendAsync(EmailModel emailModel);
    }
}
