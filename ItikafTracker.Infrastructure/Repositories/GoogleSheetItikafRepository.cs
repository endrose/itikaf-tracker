using ItikafTracker.Application.Interfaces;

using ItikafTracker.Domain.Entities;
using System.Text.Json;
using System.Globalization;
using ItikafTracker.Infrastructure.Models;



namespace ItikafTracker.Infrastructure.Repositories;

public class GoogleSheetItikafRepository : IItikafRepository
{
  private readonly HttpClient _httpClient;

  // Ganti dengan URL CSV kamu
  private const string SheetUrl = "https://script.googleusercontent.com/macros/echo?user_content_key=AY5xjrTaq-PtE2S8Ezfa-gU410v1_tSFnw1kJu6tnWAX9n1ipVRQzRNq0WwP9h7ClroXh_v6g4fgyOYVG57ILAoaN_Uca3b-r-lJXBn9n0mkXV6PUSRdy_FZjtcSl3mqrN5vgix_RZyH_HYBeW058bgny3W8b7_uaEWYVUCOIxO8VPfLkIKBuNYWXMHg7DKcDKEvsKUDa-EEcJ_x20x56ySeBsP9mCTXn_RSq__rTS9_Nq19hc2d6K2DStU-x5FJJw&lib=MazGGNBiJi8_zDu-FVj6TOxSBcQ8BraCT";

  public GoogleSheetItikafRepository(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }


  public async Task<List<Itikaf>> GetAllAsync()
  {
    var response = await _httpClient.GetStringAsync(SheetUrl);

    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    var data = JsonSerializer.Deserialize<List<ItikafDto>>(response, options);

    if (data == null)
      return new List<Itikaf>();

    return data.Select(x => new Itikaf(
        x.Id,
        x.User,
        x.Nama,
        x.Alamat,
        x.Telepon.ToString(),
        x.TanggalLahir,
        x.Asal,
        x.Awal,
        x.Akhir,
        x.Deskripsi
    )).ToList();
  }

  public Task AddAsync(Itikaf itikaf)
  {
    throw new NotImplementedException("Google Sheet CSV tidak mendukung write langsung.");
  }
}