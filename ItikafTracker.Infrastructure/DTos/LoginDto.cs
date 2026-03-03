using System.Text.Json.Serialization;

namespace ItikafTracker.Infrastructure.Models;

public class LoginDto
{
  public string Username { get; set; }
  public string Password { get; set; }
}