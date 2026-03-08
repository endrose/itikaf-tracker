using ItikafTracker.Application.Interfaces;
using ItikafTracker.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItikafTracker.API.Controllers;

[ApiController]
[Route("api/absen")]
[Authorize]

public class AbsenController : ControllerBase
{
  private readonly IItikafRepository _repository;

  public AbsenController(IItikafRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var data = await _repository.GetAbsensAsync();
    return Ok(data);
  }

  // [HttpGet("{id}")]
  // public async Task<IActionResult> GetById(int id)
  // {
  //   var data = await _repository.GetByIdAsync(id);
  //   if (data == null)
  //     return NotFound();

  //   return Ok(data);
  // }

  // //POST
  // [HttpPost]
  // public async Task<IActionResult> Post(Absen absen)
  // {
  //   await _repository.AddAsync(absen);
  //   return Ok(absen);
  // }

  // //PUT
  // [HttpPut("{id}")]
  // public async Task<IActionResult> Put(int id, Itikaf itikaf)
  // {
  //   if (id != itikaf.Id)
  //     return BadRequest("ID tidak cocok");

  //   await _repository.UpdateAsync(itikaf);
  //   return Ok(itikaf);
  // }

  // //DELETE
  // [HttpDelete("{id}")]
  // public async Task<IActionResult> Delete(int id)
  // {
  //   var existing = await _repository.GetByIdAsync(id);
  //   if (existing == null)
  //     return NotFound();

  //   await _repository.DeleteAsync(id);
  //   return NoContent();
  // }

}