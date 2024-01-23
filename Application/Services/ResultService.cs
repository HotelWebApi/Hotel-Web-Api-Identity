using Application.Common.Exceptions;
using Application.DTOs.ResultDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Rooms;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class ResultService(IUnitOfWork unitOfWork, IMapper mapper) : IResultService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<AddResultDto> AddResult(AddResultDto addResultDto)
    {
        if(addResultDto == null)
        {
            throw new ArgumentNullException(nameof(addResultDto));
        }
        var result = _mapper.Map<Result>(addResultDto);
        var results = await _unitOfWork.ResultInterface.GetAllAsync();
        if(results == null)
        {
            throw new ArgumentNullException();
        }
        if(!result.IsSuccses)
        {
            throw new CustomException("Not success");
        }
        try
        {
            await _unitOfWork.ResultInterface.AddAsync(result);
            await _unitOfWork.SaveAsync();

            return addResultDto;
        }
        catch (CustomException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task DeleteResultById(int id)
    {
        var result = await _unitOfWork.ResultInterface.GetByIdAsync(id);
        if(result == null)
        {
            throw new ArgumentNullException();
        }
        await _unitOfWork.ResultInterface.DeleteAsync(result);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<ResultDto>> GetAllResult()
    {
        var results = await _unitOfWork.ResultInterface.GetAllAsync();
        return results.Select(r => _mapper.Map<ResultDto>(r)).ToList();
    }

    public async Task<ResultDto> GetResultById(int id)
    {
        var result = await _unitOfWork.ResultInterface.GetByIdAsync(id);
        if (result == null)
        {
            throw new ArgumentNullException();
        }
        return _mapper.Map<ResultDto>(result);
    }
}