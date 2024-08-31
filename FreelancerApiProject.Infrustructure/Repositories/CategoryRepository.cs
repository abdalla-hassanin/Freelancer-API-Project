using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        
        public CategoryRepository(ApplicationDbContext context) : base(context) 
        {
            _categories = context.Set<Category>();
        }

        public Category? GetCategoryWithJobs(int id)
        {
            return _categories
                .Include(x => x.Jobs)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
