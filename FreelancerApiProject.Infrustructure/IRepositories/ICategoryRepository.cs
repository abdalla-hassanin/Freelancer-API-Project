using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;

namespace FreelancerApiProject.Infrustructure.IRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category? GetCategoryWithJobs(int id);
    }
}