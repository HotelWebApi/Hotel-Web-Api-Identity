using Application.Common.Exceptions;
using Application.DTOs.OrderDtos.OrderStatusDtos;
using Application.DTOs.RoomsDtos.OnlineBronDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, SuperAdmin, User")]
public class OnlineBronController(IOnlineBronService onlineBronService) : ControllerBase
{
    private readonly IOnlineBronService _onlineBronService = onlineBronService;
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var onlineBook = await _onlineBronService.GetAllAsync();
            return Ok(onlineBook);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try 
        {
            var onlineBook = await _onlineBronService.GetByIdAsync(id);
            return Ok(onlineBook);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }

        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddOnlineBronDto addOnlineBromDto)
    {
        try
        {
            await _onlineBronService.AddAsync(addOnlineBromDto);
            return Ok("Added");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }

        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateOnlineBronDto updateOnlineBronDto)
    {
        try
        {
            await _onlineBronService.UpdateAsync(updateOnlineBronDto);
            return Ok("Updated");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _onlineBronService.DeleteAsync(id);
            return Ok("Deleted");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

