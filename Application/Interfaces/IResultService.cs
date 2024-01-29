using Application.DTOs.ResultDtos;

namespace Application.Interfaces;
public interface IResultService
{
    Task<List<ResultDto>> GetAllResult();
    Task <ResultDto> GetResultById(int id);
    Task <AddResultDto> AddResult(AddResultDto addResultDto);
    Task DeleteResultById(int id);
}