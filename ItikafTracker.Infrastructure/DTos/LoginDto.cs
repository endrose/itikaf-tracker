using System.Text.Json.Serialization;

namespace ItikafTracker.Infrastructure.Models;

public class LoginDto
{
  public required string Username { get; set; }
  public required string Password { get; set; }
}