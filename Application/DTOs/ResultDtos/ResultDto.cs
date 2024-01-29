using Domain.Entities;

namespace Application.DTOs.ResultDtos;

public class ResultDto : IdEntity
{
    public bool IsSuccses { get; set; }
    public string FullName { get; set; } = null!;

    public string StartDate { get; set; } = null!;
    public string EndDate { get; set; } = string.Empty!;

}