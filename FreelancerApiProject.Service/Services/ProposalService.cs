using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProposalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Proposal>> GetAllAsync()
        {
            var proposals = await _unitOfWork.ProposalRepository.FindAllAsync(
                includes:
                [
                    "Freelancer",
                    "Job"
                ]
            );
            return proposals.ToList();
        }
        public async Task<List<Proposal>> GetAllByJobIdAsync(int jobId)
        {
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == jobId))  return [];

            var proposals = await _unitOfWork.ProposalRepository.FindAllAsync(
                includes: ["Freelancer", "Job"],
                criteria: p => p.JobId == jobId
            );
            return proposals.ToList();
        }
        public async Task<List<Proposal>> GetAllByFreelancerIdAsync(int freelancerId)
        {
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == freelancerId))
                return [];

            var proposals = await _unitOfWork.ProposalRepository.FindAllAsync(
                includes: ["Freelancer", "Job"],
                criteria: p => p.FreelancerId == freelancerId);
                
            return proposals.ToList();
        }
        public async Task<Proposal?> GetByIdAsync(int id)
        {
            if (!_unitOfWork.ProposalRepository.IsExist(x => x.Id == id)) return null;

            var proposal =
                await _unitOfWork.ProposalRepository.FindAsync(
                    includes:
                    [
                        "Freelancer",
                        "Job"
                    ], criteria: p => p.Id == id);

            return proposal;
        }

        public async Task<string> CreateAsync(Proposal proposal)
        {
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == proposal.FreelancerId))
                return "Freelancer not found in database";
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == proposal.JobId)) return "Job not found in database";

            await _unitOfWork.ProposalRepository.AddAsync(proposal);
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> UpdateAsync(Proposal proposal)
        {
            if (!_unitOfWork.ProposalRepository.IsExist(x => x.Id == proposal.Id))
                return "Proposal not found in database";
            if (!_unitOfWork.FreelancerRepository.IsExist(x => x.Id == proposal.FreelancerId))
                return "Freelancer not found in database";
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == proposal.JobId)) return "Job not found in database";

            
            _unitOfWork.ProposalRepository.Update(proposal);
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> DeleteAsync(Proposal proposal)
        {
            if (!_unitOfWork.ProposalRepository.IsExist(x => x.Id == proposal.Id))
                return "Proposal not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.ProposalRepository.Delete(proposal);
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

        public async Task<string> AcceptProposalAsync(Proposal proposal)
        {
            if (!_unitOfWork.ProposalRepository.IsExist(x => x.Id == proposal.Id))
                return "Proposal not found in database";
            
            // Ensure the proposal is in a state to be accepted
            if (proposal.Status != ProposalStatusEnum.Waiting)
                return "Proposal is not in a state that can be accepted";
           
            // Update proposal status and relevant fields
            proposal.Status = ProposalStatusEnum.Approved;
            proposal.ApprovedTime = DateTime.UtcNow;
            proposal.DeadLine = proposal.ApprovedTime.Value.AddDays(proposal.Duration);

            // Update the related job
            var job = await _unitOfWork.JobRepository.GetByIdAsync(proposal.JobId);
            if (job == null)
                return "Related job not found in database";
            
            // Set the job's accepted freelancer and update job status
            job.AcceptedFreelancerId = proposal.FreelancerId;
            job.Status = JobStatusEnum.Closed; 
            job.ApproveTime = DateTime.UtcNow; 
            
            _unitOfWork.JobRepository.Update(job);
            _unitOfWork.ProposalRepository.Update(proposal);
            await _unitOfWork.SaveAsync();
            return "Success";
        }
        
        public async Task<string> RejectProposalAsync(Proposal proposal)
        {
            if (!_unitOfWork.ProposalRepository.IsExist(x => x.Id == proposal.Id))
                return "Proposal not found in database";
            
            // Ensure the proposal is in a state to be rejected
            if (proposal.Status != ProposalStatusEnum.Waiting)
                return "Proposal is not in a state that can be rejected";
            
            // Update proposal status
            proposal.Status = ProposalStatusEnum.Rejected;
            _unitOfWork.ProposalRepository.Update(proposal);
            await _unitOfWork.SaveAsync();
            return "Success";
        }
    }
}