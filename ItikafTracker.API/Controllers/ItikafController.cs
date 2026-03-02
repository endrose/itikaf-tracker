using ItikafTracker.Application.Interfaces;
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
}