using ItikafTracker.Domain.Entities;

namespace ItikafTracker.Application.Interfaces;

public interface IItikafRepository
{
  Task<List<Itikaf>> GetAllAsync();
  Task AddAsync(Itikaf itikaf);
}