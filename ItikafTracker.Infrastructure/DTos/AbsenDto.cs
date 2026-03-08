using System.Text.Json.Serialization;

namespace ItikafTracker.Infrastructure.Models;

public class AbsenDto
{
  public int Id { get; set; }

  public string User { get; set; } = "";
  public string Nama { get; set; } = "";
  public string Kehadiran { get; set; } = "";

  [JsonPropertyName("Waktu")]
  public string Waktu { get; set; } = "";

}