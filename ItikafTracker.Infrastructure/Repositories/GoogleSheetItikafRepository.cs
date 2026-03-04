using System.Text;
using System.Text.Json;
using ItikafTracker.Application.Interfaces;

using ItikafTracker.Domain.Entities;
using ItikafTracker.Infrastructure.Models;



namespace ItikafTracker.Infrastructure.Repositories;

public class GoogleSheetItikafRepository : IItikafRepository
{
  private readonly HttpClient _httpClient;

  // Ganti dengan URL CSV kamu
  private const string SheetUrl = "https://script.google.com/macros/s/AKfycbw6d75q_t8uuCr6n0LqmtW7jV0v8uCahKhXUvZzkxotEdoOejQvpeG95j6CGl6nuDQA/exec";

  private const string SheetUrlPost = "https://script.google.com/macros/s/AKfycbwkuuZYeIrTr1ANp_4N9hUlJKTBR4pUCccPkAvb1ic2GUAzbJCjr6NkJc3TaFfIpOwN/exec";

  private const string SheetUrlPut = "https://script.google.com/macros/s/AKfycbzlVRexTEEvFCBgjghTPkavZyDXFOxyaKcSUhad3bS9n3FcYuzZqiJE7CS1SBAMyNRu/exec";


  //  

  public GoogleSheetItikafRepository(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }


  public async Task<List<Itikaf>> GetAllAsync()
  {

    try
    {
      var response = await _httpClient.GetStringAsync(SheetUrl);

      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };

      var data = JsonSerializer.Deserialize<List<ItikafDto>>(response, options);


      Console.WriteLine("Data dari Google Sheet:" + response);
      if (data == null)
        return new List<Itikaf>();

      return data.Select(x => new Itikaf(
          x.Id,
          x.User,
          x.Nama,
          x.Alamat,
          x.Telepon.ToString(),
             DateTime.Parse(x.TanggalLahir),
    x.Asal,
    DateTime.Parse(x.Awal),
    DateTime.Parse(x.Akhir),
          x.Deskripsi
      )).ToList();
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saat mengambil data dari Google Sheet: " + ex.Message);

      return new List<Itikaf>();
    }

  }

  public async Task AddAsync(Itikaf itikaf)
  {

    try
    {
      var json = JsonSerializer.Serialize(new
      {
        action = "create",
        itikaf.Id,
        itikaf.User,
        itikaf.Nama,
        itikaf.Alamat,
        itikaf.Telepon,
        itikaf.TanggalLahir,
        itikaf.Asal,
        itikaf.Awal,
        itikaf.Akhir,
        itikaf.Deskripsi
      });

      var content = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(SheetUrlPost, content);

      Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saat POST: " + ex.Message);
    }
  }

  public Task<Itikaf> GetByIdAsync(int id)
  {
    try
    {
      var response = _httpClient.GetStringAsync(SheetUrl).Result;

      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };

      var data = JsonSerializer.Deserialize<List<ItikafDto>>(response, options);

      Console.WriteLine("Data dari Google Sheet:" + response);
      if (data == null)
        return Task.FromResult<Itikaf>(null);

      var item = data.FirstOrDefault(x => x.Id == id);
      if (item == null)
        return Task.FromResult<Itikaf>(null);

      var itikaf = new Itikaf(
          item.Id,
          item.User,
          item.Nama,
          item.Alamat,
          item.Telepon.ToString(),
             DateTime.Parse(item.TanggalLahir),
    item.Asal,
    DateTime.Parse(item.Awal),
    DateTime.Parse(item.Akhir),
          item.Deskripsi
      );

      return Task.FromResult(itikaf);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saat mengambil data berdasarkan ID dari Google Sheet: " + ex.Message);
      throw;
    }
  }

  public async Task UpdateAsync(Itikaf itikaf)
  {
    try
    {
      var json = JsonSerializer.Serialize(new
      {
        action = "update",
        itikaf.Id,
        itikaf.User,
        itikaf.Nama,
        itikaf.Alamat,
        itikaf.Telepon,
        itikaf.TanggalLahir,
        itikaf.Asal,
        itikaf.Awal,
        itikaf.Akhir,
        itikaf.Deskripsi
      });

      var content = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(SheetUrlPut, content);

      var result = await response.Content.ReadAsStringAsync();
      Console.WriteLine(result);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saat mengupdate data di Google Sheet: " + ex.Message);
      throw;
    }

  }
  

  public async Task DeleteAsync(int id)
  {
    try
    {
      var json = JsonSerializer.Serialize(new
      {
        action = "delete",
        id
      });

      var content = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(SheetUrlPut, content);

      var result = await response.Content.ReadAsStringAsync();
      Console.WriteLine(result);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error saat menghapus data di Google Sheet: " + ex.Message);
      throw;
    }

  } 
}