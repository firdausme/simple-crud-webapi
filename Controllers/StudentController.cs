using Microsoft.AspNetCore.Mvc;
using SimpleCrudWebApi.DTOs.Requests;
using SimpleCrudWebApi.Exceptions;
using SimpleCrudWebApi.Services;

namespace SimpleCrudWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(
            await service.GetAll()
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(
                await service.GetById(id)
            );
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        try
        {
            return Ok(
                await service.GetByEmail(email)
            );
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(StudentRequest request)
    {
        try
        {
            await service.Add(request);
            return CreatedAtAction(nameof(GetByEmail), new { request.Email }, request);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(StudentRequest request)
    {
        try
        {
            await service.Update(request);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await service.Delete(id);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}