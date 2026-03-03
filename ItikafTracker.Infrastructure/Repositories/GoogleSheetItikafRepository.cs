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

  private const string SheetUrlPut = "https://script.google.com/macros/s/AKfycbxd_K3fEeppIZO6wAVKQ3sUCD0GY8Z5U1stqLF0erpH1Ie-39avzarbgAxBGsCQqI76/exec";

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
      var json = JsonSerializer.Serialize(itikaf);

      var content = new StringContent(
          json,
          System.Text.Encoding.UTF8,
          "application/json"
      );

      var response = await _httpClient.PostAsync(SheetUrlPost, content);

      var responseBody = await response.Content.ReadAsStringAsync();

      Console.WriteLine("Response dari Google Script:");
      Console.WriteLine(responseBody);

      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Gagal menambahkan data: " + response.StatusCode);
      }
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
    var json = JsonSerializer.Serialize(itikaf);

    var request = new HttpRequestMessage(HttpMethod.Put, SheetUrlPut)
    {
      Content = new StringContent(json, Encoding.UTF8, "application/json")
    };

    var response = await _httpClient.SendAsync(request);

    var result = await response.Content.ReadAsStringAsync();
    Console.WriteLine(result);
  }
}