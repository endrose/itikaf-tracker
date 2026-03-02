using System.Text.Json.Serialization;

namespace ItikafTracker.Infrastructure.Models;

public class ItikafDto
{
  public int Id { get; set; }
  public string User { get; set; } = "";
  public string Nama { get; set; } = "";
  public string Alamat { get; set; } = "";
  public long Telepon { get; set; }

  [JsonPropertyName("Tanggal Lahir")]
  public DateTime TanggalLahir { get; set; }

  public string Asal { get; set; } = "";
  public DateTime Awal { get; set; }
  public DateTime Akhir { get; set; }
  public string Deskripsi { get; set; } = "";
}