using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;


        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Category>> GetAllAsync()
        {
            var categorys = await _unitOfWork.CategoryRepository.FindAllAsync(includes: ["Jobs"]
              );

            return categorys.ToList();
        }

  
        public async Task<Category?> GetByIdAsync(int id)
        {
            if (!_unitOfWork.CategoryRepository.IsExist(x => x.Id == id)) return null;

            var category =
                await _unitOfWork.CategoryRepository.FindAsync(includes: ["Jobs"],
                    criteria: p => p.Id == id);

            return category;
        }

        public async Task<string> CreateAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync(); 
            return "Success";
        }
        
        public async Task<string> UpdateAsync(Category category)
        {
            if (!_unitOfWork.CategoryRepository.IsExist(x => x.Id == category.Id)) return "category not found in database";

            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> DeleteAsync(Category category)
        {
            if (!_unitOfWork.CategoryRepository.IsExist(x => x.Id == category.Id)) return "category not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.CategoryRepository.Delete(category);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "Failed";
            }
        }
    }
}