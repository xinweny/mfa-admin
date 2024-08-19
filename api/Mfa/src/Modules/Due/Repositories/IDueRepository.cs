using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IDueRepository {
    Task<IEnumerable<Due>> GetDues(GetDuesRequest? req);
    Task CreateDues(IEnumerable<Due> due);
    Task UpdateDue(Due due, UpdateDueRequest req);
    Task DeleteDue(Due due);
}