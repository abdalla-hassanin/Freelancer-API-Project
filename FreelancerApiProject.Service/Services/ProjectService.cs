using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Project>> GetAllAsync()
        {
            var projects = await _unitOfWork.ProjectRepository.FindAllAsync(includes: ["Skills","Skills.Skill"]
              );

            return projects.ToList();
        }

        public async Task<List<Project>> GetAllByFreelancerIdAsync(int freelancerId)
        {
            var projects = await _unitOfWork.ProjectRepository.FindAllAsync(includes: ["Skills", "Skills.Skill"],
                criteria: p => p.FreelancerId == freelancerId);

            return projects.ToList();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var project =
                await _unitOfWork.ProjectRepository.FindAsync(includes: ["Skills", "Skills.Skill"],
                    criteria: p => p.Id == id);

            return project;
        }

        public async Task<string> CreateAsync(Project project, List<int>? requestSkillIDs)
        {
            if (project.FreelancerId != 0 &&
                !_unitOfWork.FreelancerRepository.IsExist(x => x.Id == project.FreelancerId))
            {
                return "Freelancer not found in database";
            }

            await _unitOfWork.ProjectRepository.AddAsync(project);
            await _unitOfWork.SaveAsync(); // Save to generate the project's ID

            // Add ProjectSkills
            if (requestSkillIDs != null)
                await AddProjectSkillsAsync(project.Id, requestSkillIDs);


            return "Success";
        }

        private async Task AddProjectSkillsAsync(int projectId, List<int> skillIds)
        {
            var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillIds.Contains(s.Id));
            var projectSkills = skills.Select(skill => new ProjectSkills
            {
                SkillId = skill.Id,
                ProjectId = projectId
            }).ToList();

            await _unitOfWork.ProjectSkillsRepository.AddRangeAsync(projectSkills);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> UpdateAsync(Project project, List<int>? requestSkillIDs)
        {
            if (!_unitOfWork.ProjectRepository.IsExist(x => x.Id == project.Id)) return "Project not found in database";
            if (project.FreelancerId != 0 &&
                !_unitOfWork.FreelancerRepository.IsExist(x => x.Id == project.FreelancerId))
                return "Freelancer not found in database";
            _unitOfWork.ProjectRepository.Update(project);
            if (requestSkillIDs!=null) await UpdateProjectSkillsAsync(project.Id, requestSkillIDs);
            
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        private async Task UpdateProjectSkillsAsync(int projectId, List<int> skillIds)
        {
            // Get existing skills for the project
            var existingSkills = await _unitOfWork.ProjectSkillsRepository
                .FindAllAsync(criteria: ps => ps.ProjectId == projectId);
        
            var existingSkillIds = existingSkills.Select(ps => ps.SkillId).ToList();

            // Determine skills to remove
            var skillsToRemove = existingSkills.Where(ps => !skillIds.Contains(ps.SkillId)).ToList();

            // Determine skills to add
            var skillsToAdd = skillIds.Except(existingSkillIds).ToList();

            // Perform removals
            if (skillsToRemove.Any())
            {
                _unitOfWork.ProjectSkillsRepository.DeleteRange(skillsToRemove);
            }

            // Perform additions
            if (skillsToAdd.Any())
            {
                var skills = await _unitOfWork.SkillRepository.FindAllAsync(criteria: s => skillsToAdd.Contains(s.Id));
                var projectSkillsToAdd = skills.Select(skill => new ProjectSkills
                {
                    SkillId = skill.Id,
                    ProjectId = projectId
                }).ToList();

                await _unitOfWork.ProjectSkillsRepository.AddRangeAsync(projectSkillsToAdd);
            }
        }
        public async Task<string> DeleteAsync(Project project)
        {
            if (!_unitOfWork.ProjectRepository.IsExist(x => x.Id == project.Id)) return "Project not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.ProjectRepository.Delete(project);
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