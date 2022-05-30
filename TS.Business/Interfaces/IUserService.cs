using TS.Model.Entities;
using TS.Model.ViewModels;

namespace TS.Business.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);

    Task<User?> AddAsync(User user);

    Task<User> UpdateAsync(User user);

    Task<bool> DeleteAsync(int id);
}