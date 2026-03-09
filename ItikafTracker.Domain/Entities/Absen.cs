namespace ItikafTracker.Domain.Entities;

public class Absen
{
  public int Id { get; private set; }
  public string User { get; private set; }
  public string Nama { get; private set; }
  public string Kehadiran { get; private set; }
  public DateTime Waktu { get; private set; }


  public Absen(
      int id,
      string user,
      string nama,
      string kehadiran,
      DateTime waktu

      )
  {
   
    Id = id;
    User = user;
    Nama = nama;
    Kehadiran = kehadiran;
    Waktu = waktu;
  }
  
}