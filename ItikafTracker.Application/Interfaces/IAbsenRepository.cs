using ItikafTracker.Domain.Entities;

namespace ItikafTracker.Application.Interfaces;

public interface IAbsenRepository
{

  Task<List<Absen>> GetAbsensAsync();


  Task<Absen> GetByIdAbsenAsync(int id);

  Task AddAbsenAsync(Absen absen);

  Task UpdateAbsenAsync(Absen absen);

  Task DeleteAbsenAsync(int id);
}