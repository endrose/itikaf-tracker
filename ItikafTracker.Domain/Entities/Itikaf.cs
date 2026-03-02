namespace ItikafTracker.Domain.Entities;

public class Itikaf
{
  public int Id { get; private set; }
  public string User { get; private set; }
  public string Nama { get; private set; }
  public string Alamat { get; private set; }
  public string Telepon { get; private set; }
  public DateTime TanggalLahir { get; private set; }
  public string Asal { get; private set; }
  public DateTime Awal { get; private set; }
  public DateTime Akhir { get; private set; }
  public string Deskripsi { get; private set; }

  public Itikaf(
      int id,
      string user,
      string nama,
      string alamat,
      string telepon,
      DateTime tanggalLahir,
      string asal,
      DateTime awal,
      DateTime akhir,
      string deskripsi)
  {
    if (akhir < awal)
      throw new ArgumentException("Tanggal akhir tidak boleh sebelum tanggal awal");

    Id = id;
    User = user;
    Nama = nama;
    Alamat = alamat;
    Telepon = telepon;
    TanggalLahir = tanggalLahir;
    Asal = asal;
    Awal = awal;
    Akhir = akhir;
    Deskripsi = deskripsi;
  }
}