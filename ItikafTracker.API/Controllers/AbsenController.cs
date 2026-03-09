using ItikafTracker.Application.Interfaces;
using ItikafTracker.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItikafTracker.API.Controllers;

[ApiController]
[Route("api/absen")]
[Authorize]

public class AbsenController(IAbsenRepository repository) : ControllerBase
{
  private readonly IAbsenRepository _repository = repository;

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var data = await _repository.GetAbsensAsync();
    return Ok(data);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var data = await _repository.GetByIdAbsenAsync(id);
    if (data == null)
      return NotFound();

    return Ok(data);
  }

  //POST
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Absen absen)
  {
    await _repository.AddAbsenAsync(absen);
    return Ok(absen);
  }

  //PUT
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Absen absen)
  {
    if (id != absen.Id)
      return BadRequest("ID tidak cocok");

    await _repository.UpdateAbsenAsync(absen);
    return Ok(absen);
  }



  //DELETE
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var existing = await _repository.GetByIdAbsenAsync(id);
    if (existing == null)
      return NotFound();

    await _repository.DeleteAbsenAsync(id);
    return NoContent();
  }

}