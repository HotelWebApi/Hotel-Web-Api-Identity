using Domain.Entities;
using Domain.Entities.Rooms;

namespace Application.DTOs.ClientDtos;

public class ClientDto : IdEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CheckIn { get; set; } = null!;
    public string CheckOut { get; set; } = null!;
    public int PersonCount { get; set; }
    public int RoomId { get; set; }
}
