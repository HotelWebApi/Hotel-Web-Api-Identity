using Application.Common;
using Application.DTOs.ClientDtos;
using Application.DTOs.RoomsDtos.OnlineBronDtos;

namespace Application.Interfaces;

public interface IOnlineBronService
{
    Task<List<OnlineBronDto>> GetAllAsync();
    Task<OnlineBronDto> GetByIdAsync(int id);
    Task AddAsync(AddOnlineBromDto addOnlineBromDto);
    Task UpdateAsync(UpdateOnlineBronDto updateOnlineBronDto);
    Task DeleteAsync(int id);
}
