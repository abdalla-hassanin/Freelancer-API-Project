using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerApiProject.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Constructor to inject the unit of work
        public JobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Retrieves all jobs with their related entities
        public async Task<List<Job>> GetAllAsync()
        {
            return (await _unitOfWork.JobRepository.FindAllAsync(includes:
                [
                    "Client",
                    "Category",
                    "Category.Jobs",
                    "Skills.Skill",
                    "Proposals",
                    "AcceptedFreelancer",
                    "Rate"
                ]
            )).ToList();
        }

        // Retrieves a job by its ID with its related entities
        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _unitOfWork.JobRepository.FindAsync(includes:
                [
                    "Client",
                    "Category",
                    "Category.Jobs",
                    "Skills.Skill",
                    "Proposals",
                    "AcceptedFreelancer",
                    "Rate"
                ],
                criteria: j => j.Id == id);
        }

        // Creates a new job and optionally associates skills with it
        public async Task<string> CreateAsync(Job job, List<int>? skillIds)
        {
            await _unitOfWork.JobRepository.AddAsync(job);
            await _unitOfWork.SaveAsync(); // Save to generate the job's ID

            if (skillIds != null)
                await AddJobSkillsAsync(job.Id, skillIds);

            return "Success";
        }

        // Adds skills to a job
        private async Task AddJobSkillsAsync(int jobId, List<int> skillIds)
        {
            var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillIds.Contains(s.Id));
            var jobSkills = skills.Select(skill => new JobSkills
            {
                SkillId = skill.Id,
                JobId = jobId
            }).ToList();

            await _unitOfWork.JobSkillsRepository.AddRangeAsync(jobSkills);
            await _unitOfWork.SaveAsync();
        }

        // Updates an existing job and optionally updates its associated skills
        public async Task<string> UpdateAsync(Job job, List<int>? skillIds)
        {
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == job.Id)) return "Job not found in database";

            _unitOfWork.JobRepository.Update(job);
            if (skillIds != null) await UpdateJobSkillsAsync(job.Id, skillIds);

            await _unitOfWork.SaveAsync();
            return "Success";
        }

        // Updates the skills associated with a job
        private async Task UpdateJobSkillsAsync(int jobId, List<int> skillIds)
        {
            var existingSkills = await _unitOfWork.JobSkillsRepository.FindAllAsync(criteria: js => js.JobId == jobId);
            var existingSkillIds = existingSkills.Select(js => js.SkillId).ToList();

            var skillsToRemove = existingSkills.Where(js => !skillIds.Contains(js.SkillId)).ToList();
            var skillsToAdd = skillIds.Except(existingSkillIds).ToList();

            if (skillsToRemove.Any())
            {
                _unitOfWork.JobSkillsRepository.DeleteRange(skillsToRemove);
            }

            if (skillsToAdd.Any())
            {
                var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillsToAdd.Contains(s.Id));
                var jobSkillsToAdd = skills.Select(skill => new JobSkills
                {
                    SkillId = skill.Id,
                    JobId = jobId
                }).ToList();

                await _unitOfWork.JobSkillsRepository.AddRangeAsync(jobSkillsToAdd);
            }
        }

        // Deletes a job and ensures related entities are also deleted
        public async Task<string> DeleteAsync(Job job)
        {
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == job.Id))
                return "Job not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.JobRepository.Delete(job);
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

        public async Task<List<Job>> GetAllByCategoryIdAsync(int categoryId)
        {
            return (await _unitOfWork.JobRepository.FindAllAsync(
                criteria: j => j.CategoryId == categoryId,
                includes: ["Client", "Skills.Skill", "Proposals", "AcceptedFreelancer", "Rate"]
            )).ToList();
        }

        public async Task<List<Job>> GetAllByFreelancerIdAsync(int freelancerId)
        {
            return (await _unitOfWork.JobRepository.FindAllAsync(
                criteria: j => j.AcceptedFreelancerId == freelancerId,
                includes: ["Client", "Category", "Skills.Skill", "Proposals", "Rate"]
            )).ToList();
        }

        public async Task<List<Job>> GetAllByClientIdAsync(int clientId)
        {
            return (await _unitOfWork.JobRepository.FindAllAsync(
                criteria: j => j.ClientId == clientId,
                includes: ["Category", "Skills.Skill", "Proposals", "AcceptedFreelancer", "Rate"]
            )).ToList();
        }

        public async Task<List<Job>> GetAllByTitleAsync(string title)
        {
            return (await _unitOfWork.JobRepository.FindAllAsync(
                criteria: j => j.Title.Contains(title),
                includes: ["Client", "Category", "Skills.Skill", "Proposals", "AcceptedFreelancer", "Rate"]
            )).ToList();
        }

        public async Task<PaginatedListModel<Job>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            var jobs = await _unitOfWork.JobRepository.FindAllPaginatedAsync(
                pageNumber: pageNumber,
                pageSize: pageSize,
                includes: ["Client", "Category", "Skills.Skill", "Proposals", "AcceptedFreelancer", "Rate"]
            );

            return new PaginatedListModel<Job>
            {
                Items = jobs.Items.ToList(),
                TotalItems = jobs.TotalItems,
                TotalPages = jobs.CurrentPage,
                CurrentPage = jobs.TotalPages
            };

        }
    }
}