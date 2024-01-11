using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.DTOs.ClientDtos;
using Application.DTOs.GuestDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Clients;
using Domain.Entities.Guests;
using Infrastructure.Interfaces;

namespace Application.Services;

public class ClientService(IUnitOfWork unitOfWork, IMapper mapper) : IClientService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddAsync(AddClientDto addClientDto)
    {
        if (addClientDto == null)
        {
            throw new ArgumentNullException(nameof(addClientDto));
        }

        var client = _mapper.Map<Client>(addClientDto);
        try
        {
            var clients = await _unitOfWork.ClientInterface.GetAllAsync();
            if (client.IsExsit(clients))
            {
                throw new CustomException($"{client.RoomId} already exist");
            }
            await _unitOfWork.ClientInterface.AddAsync(client);
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
        var clientTask = _unitOfWork.ClientInterface.GetByIdAsync(id);
        var client = await clientTask;

        if (!client.IsValid())
        {
            throw new CustomException($"{nameof(Client)} cannot be deleted");
        }
        await _unitOfWork.ClientInterface.DeleteAsync(client);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<ClientDto>> GetAllAsync()
    {
        var guests = await _unitOfWork.ClientInterface.GetAllAsync();
        return guests.Select(g => _mapper.Map<ClientDto>(g))
                         .ToList();
    }

    public async Task<PagedList<ClientDto>> GetAllPagedAsync(int pageSize, int pageNumber)
    {
        var clients = await GetAllAsync();
        PagedList<ClientDto> pagedList = new(clients, clients.Count, pageNumber, pageSize);
        return pagedList.ToPagedList(clients,
                                      pageSize,
                                      pageNumber);

    }

    public async Task<ClientDto> GetByIdAsync(int id)
    {
        var guest = await _unitOfWork.ClientInterface.GetByIdAsync(id);
        if (guest is null)
        {
            throw new ArgumentException("Education is not");
        }
        return _mapper.Map<ClientDto>(guest);
    }

    public async Task UpdateAsync(UpdateClientDto updateClientDto)
    {
        if (updateClientDto is null)
        {
            throw new ArgumentNullException(nameof(updateClientDto), "Updated guest information is null");
        }

        var client = await _unitOfWork.ClientInterface.GetByIdAsync(updateClientDto.Id);

        if (client is null)
        {
            throw new ArgumentException($"No guest found with ID {updateClientDto.Id}", nameof(updateClientDto.Id));
        }

        _mapper.Map(updateClientDto, client);

        if (!client.IsValid())
        {
            throw new CustomException("Guest information is invalid!");
        }

        var clients = await _unitOfWork.ClientInterface.GetAllAsync();
        if (client.IsExsit(clients))
        {
            throw new CustomException($"{client.RoomId} already exist");
        }

        await _unitOfWork.ClientInterface.UpdateAsync(client);
        await _unitOfWork.SaveAsync();
    }
}
