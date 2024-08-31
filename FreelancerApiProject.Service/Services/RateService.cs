using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class RateService : IRateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Rate>> GetAll()
        {
            var rates = await _unitOfWork.RateRepository.FindAllAsync();
            return rates.ToList();
        }

        public async Task<Rate?> GetById(int id)
        {
            var rate = await _unitOfWork.RateRepository
                .GetByIdAsync(id);

            return rate;
        }


        public async Task<string> CreateRate(Rate rate)
        {
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == rate.JobId))
            {
                return "Job not found in database";
            }
            await _unitOfWork.RateRepository.AddAsync(rate);
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> UpdateRate(Rate rate)
        {
            if (!_unitOfWork.RateRepository.IsExist(x => x.Id == rate.Id)) return "Rate not found in database";
            if (!_unitOfWork.JobRepository.IsExist(x => x.Id == rate.JobId)) return "Job not found in database";
            
            _unitOfWork.RateRepository.Update(rate);
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> DeleteRate(Rate rate)
        {
            if (!_unitOfWork.RateRepository.IsExist(x => x.Id == rate.Id)) return "Rate not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.RateRepository.Delete(rate);
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