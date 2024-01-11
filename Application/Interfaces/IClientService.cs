using Application.Common;
using Application.DTOs.ClientDtos;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task<PagedList<ClientDto>> GetAllPagedAsync(int pageSize, int pageNumber);
        Task AddAsync(AddClientDto addClientDto);
        Task UpdateAsync(UpdateClientDto updateClientDto);
        Task DeleteAsync(int id);
    }
}
