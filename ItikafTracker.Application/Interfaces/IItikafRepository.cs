using ItikafTracker.Domain.Entities;

namespace ItikafTracker.Application.Interfaces;

public interface IItikafRepository
{
  Task<List<Itikaf>> GetAllAsync();

  Task<Itikaf> GetByIdAsync(int id);

  Task AddAsync(Itikaf itikaf);

  Task UpdateAsync(Itikaf itikaf);
}