using TS.Model.Entities;

namespace TS.Business.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByIdWithTasksAsync(int id);

    Task<User?> AddAsync(User user);

    Task<User> UpdateAsync(User user);

    Task<bool> DeleteAsync(int id);
}