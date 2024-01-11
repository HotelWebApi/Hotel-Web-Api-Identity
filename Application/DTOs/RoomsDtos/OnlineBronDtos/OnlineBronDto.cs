using Domain.Entities;

namespace Application.DTOs.RoomsDtos.OnlineBronDtos;

public class OnlineBronDto : IdEntity
{
    public int RoomNumber { get; set; }
    public int PersonCount { get; set; }
    public int OrderStatus { get; set; }

    public string StartDate { get; set; } = string.Empty!;
    public string EndDate { get; set; } = string.Empty!;
    public decimal Price { get; set; }
}
