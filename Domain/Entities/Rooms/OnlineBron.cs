namespace Domain.Entities.Rooms;

public class OnlineBron : IdEntity
{
    public int RoomNumber { get; set; }
    public int PersonCount { get; set; }
    public int OrderStatus { get; set; }

    public string StartDate { get; set; } = string.Empty!;
    public string EndDate { get; set; } = string.Empty!;
    public decimal Price { get; set; }
}
