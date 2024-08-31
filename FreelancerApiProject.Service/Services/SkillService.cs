using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            var skills = await _unitOfWork.SkillRepository.FindAllAsync();

            return skills.ToList();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            var skill = await _unitOfWork.SkillRepository
                .FindAsync(criteria: s => s.Id == id);

            return skill;
        }
    }
}