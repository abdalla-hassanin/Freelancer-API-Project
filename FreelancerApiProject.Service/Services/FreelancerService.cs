using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IUnitOfWork _unitOfWork;


        public FreelancerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Freelancer>> GetAllAsync()
        {
            var freelancers = await _unitOfWork.FreelancerRepository.FindAllAsync(includes:
                [
                    "Skills.Skill",
                    "Portfolio",
                    "Portfolio.Skills.Skill",
                    "WorkingHistory",
                    "WorkingHistory.Category",
                    "WorkingHistory.Rate",
                    "WorkingHistory.Skills.Skill",
                    "WorkingHistory.Proposals",
                    "WorkingHistory.Client",
                ]
            );

            return freelancers.ToList();
        }


        public async Task<Freelancer?> GetByIdAsync(int id)
        {
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == id)) return null;

            var freelancer =
                await _unitOfWork.FreelancerRepository.FindAsync(includes:
                    [
                        "Skills.Skill",
                        "Portfolio",
                        "Portfolio.Skills.Skill",
                        "WorkingHistory",
                        "WorkingHistory.Category",
                        "WorkingHistory.Rate",
                        "WorkingHistory.Skills.Skill",
                        "WorkingHistory.Proposals",
                        "WorkingHistory.Client",
                    ],
                    criteria: p => p.Id == id);

            return freelancer;
        }

         public async Task<string> CreateAsync(Freelancer freelancer, List<int>? requestSkillIds)
        {
            await _unitOfWork.FreelancerRepository.AddAsync(freelancer);
            await _unitOfWork.SaveAsync(); // Save to generate the freelancer's ID

            // Add freelancerSkills
            if (requestSkillIds != null)
                await AddFreelancerSkillsAsync(freelancer.Id, requestSkillIds);


            return "Success";
        }

        private async Task AddFreelancerSkillsAsync(int freelancerId, List<int> skillIds)
        {
            var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillIds.Contains(s.Id));
            var freelancerSkills = skills.Select(skill => new FreelancerSkills
            {
                SkillId = skill.Id,
                FreelancerId = freelancerId
            }).ToList();

            await _unitOfWork.FreelancerSkillsRepository.AddRangeAsync(freelancerSkills);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> UpdateAsync(Freelancer freelancer, List<int>? requestSkillIds)
        {
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == freelancer.Id)) return "freelancer not found in database";

            _unitOfWork.FreelancerRepository.Update(freelancer);
            if (requestSkillIds!=null) await UpdateFreelancerSkillsAsync(freelancer.Id, requestSkillIds);
            
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        private async Task UpdateFreelancerSkillsAsync(int freelancerId, List<int> skillIds)
        {
            // Get existing skills for the freelancer
            var existingSkills = await _unitOfWork.FreelancerSkillsRepository
                .FindAllAsync(criteria: ps => ps.FreelancerId == freelancerId);
        
            var existingSkillIds = existingSkills.Select(ps => ps.SkillId).ToList();

            // Determine skills to remove
            var skillsToRemove = existingSkills.Where(ps => !skillIds.Contains(ps.SkillId)).ToList();

            // Determine skills to add
            var skillsToAdd = skillIds.Except(existingSkillIds).ToList();

            // Perform removals
            if (skillsToRemove.Any())
            {
                _unitOfWork.FreelancerSkillsRepository.DeleteRange(skillsToRemove);
            }

            // Perform additions
            if (skillsToAdd.Any())
            {
                var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillsToAdd.Contains(s.Id));
                var freelancerSkillsToAdd = skills.Select(skill => new FreelancerSkills
                {
                    SkillId = skill.Id,
                    FreelancerId = freelancerId
                }).ToList();

                await _unitOfWork.FreelancerSkillsRepository.AddRangeAsync(freelancerSkillsToAdd);
            }
        }

        public async Task<string> DeleteAsync(Freelancer freelancer)
        {
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == freelancer.Id))
                return "Freelancer not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.FreelancerRepository.Delete(freelancer);
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