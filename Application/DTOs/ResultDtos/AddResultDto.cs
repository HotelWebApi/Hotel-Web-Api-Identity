namespace Application.DTOs.ResultDtos;

public class AddResultDto
{
    public bool IsSuccses { get; set; }
    public string UserId { get; } = null!;
    public string FullName { get; set; } = null!;

    public string StartDate { get; set; } = null!;
    public string EndDate { get; set; } = string.Empty!;
}
