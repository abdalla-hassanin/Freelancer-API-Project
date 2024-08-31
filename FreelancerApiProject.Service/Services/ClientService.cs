
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Client>> GetAllAsync()
        {
            var clients = await _unitOfWork.ClientRepository.FindAllAsync(
                includes:["Jobs"]
                );
            return clients.ToList();
        }


        public async Task<Client?> GetByIdAsync(int id)
        {
            if (!_unitOfWork.ClientRepository.IsExist(x => x.Id == id)) return null;

            var client =
                await _unitOfWork.ClientRepository.FindAsync(includes:
                    ["Jobs"],
                    criteria: p => p.Id == id);

            return client;
        }

         public async Task<string> CreateAsync(Client client)
        {
            await _unitOfWork.ClientRepository.AddAsync(client);
            await _unitOfWork.SaveAsync(); 
            return "Success";
        }

        public async Task<string> UpdateAsync(Client client)
        {
            if (!_unitOfWork.ClientRepository.IsExist(x => x.Id == client.Id)) return "client not found in database";

            _unitOfWork.ClientRepository.Update(client);
            
            await _unitOfWork.SaveAsync();
            return "Success";
        }

        public async Task<string> DeleteAsync(Client client)
        {
            if (!_unitOfWork.ClientRepository.IsExist(x => x.Id == client.Id))
                return "client not found in database";

            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.ClientRepository.Delete(client);
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