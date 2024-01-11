using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.DTOs.ClientDtos;
using Application.DTOs.GuestDtos;
using Application.DTOs.RoomsDtos.OnlineBronDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Clients;
using Domain.Entities.Guests;
using Domain.Entities.Rooms;
using Infrastructure.Interfaces;

namespace Application.Services;

public class OnlineBronService(IUnitOfWork unitOfWork, IMapper mapper) : IOnlineBronService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddAsync(AddOnlineBromDto addOnlineBromDto)
    {
        if (addOnlineBromDto == null)
        {
            throw new ArgumentNullException(nameof(addOnlineBromDto));
        }

        var onlineBron = _mapper.Map<OnlineBron>(addOnlineBromDto);
        try
        {
            await _unitOfWork.OnlineBronInterface.AddAsync(onlineBron);
            await _unitOfWork.SaveAsync();
        }
        catch (CustomException ex)
        {
            throw new Exception(ex.Message);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var guestTask = _unitOfWork.OnlineBronInterface.GetByIdAsync(id);
        var guest = await guestTask;

        await _unitOfWork.OnlineBronInterface.DeleteAsync(guest);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<OnlineBronDto>> GetAllAsync()
    {
        var guests = await _unitOfWork.OnlineBronInterface.GetAllAsync();
        return guests.Select(g => _mapper.Map<OnlineBronDto>(g))
                     .ToList();
    }

    public async Task<OnlineBronDto> GetByIdAsync(int id)
    {
        var guest = await _unitOfWork.OnlineBronInterface.GetByIdAsync(id);
        if (guest is null)
        {
            throw new ArgumentException("Education is not");
        }
        return _mapper.Map<OnlineBronDto>(guest);
    }

    public async Task UpdateAsync(UpdateOnlineBronDto updateOnlineBronDto)
    {
        if (updateOnlineBronDto is null)
        {
            throw new ArgumentNullException(nameof(updateOnlineBronDto), "Updated guest information is null");
        }

        var onlineBron = await _unitOfWork.OnlineBronInterface.GetByIdAsync(updateOnlineBronDto.Id);
        var guests = await _unitOfWork.OnlineBronInterface.GetAllAsync();

        if (onlineBron is null)
        {
            throw new ArgumentException($"No guest found with ID {updateOnlineBronDto.Id}", nameof(updateOnlineBronDto.Id));
        }

        _mapper.Map(updateOnlineBronDto, onlineBron);

        await _unitOfWork.OnlineBronInterface.UpdateAsync(onlineBron);
        await _unitOfWork.SaveAsync();
    }
}
