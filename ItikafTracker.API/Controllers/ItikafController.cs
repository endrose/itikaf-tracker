using ItikafTracker.Application.Interfaces;
using ItikafTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ItikafTracker.API.Controllers;

[ApiController]
[Route("api/itikaf")]
public class ItikafController : ControllerBase
{
  private readonly IItikafRepository _repository;

  public ItikafController(IItikafRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var data = await _repository.GetAllAsync();
    return Ok(data);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var data = await _repository.GetByIdAsync(id);
    if (data == null)
      return NotFound();

    return Ok(data);
  }

  //POST
  [HttpPost]
  public async Task<IActionResult> Post(Itikaf itikaf)
  {
    await _repository.AddAsync(itikaf);
    return Ok(itikaf);
  }

  //PUT
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Itikaf itikaf)
  {
    if (id != itikaf.Id)
      return BadRequest("ID tidak cocok");

    await _repository.UpdateAsync(itikaf);
    return Ok(itikaf);
  }

}