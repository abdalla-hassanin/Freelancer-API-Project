using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface IRateService 
    {
       Task<List<Rate>> GetAll();

       Task<Rate?> GetById(int id);

       Task<string> CreateRate(Rate rate);

       Task<string> UpdateRate(Rate rate);

       Task<string> DeleteRate(Rate rate);
       
     
    }
}