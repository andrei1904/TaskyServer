using Microsoft.EntityFrameworkCore;
using TS.Business.Interfaces;
using TS.Model.Entities;
using TS.Repository;
using Task = TS.Model.Entities.Task;

namespace TS.Business.Implementations;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IHashingHelper _hashingHelper;

    public UserService(DataContext context, IHashingHelper authorizationHelper)
    {
        _context = context;
        _hashingHelper = authorizationHelper;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
    }

    public async Task<User?> GetByIdWithTasksAsync(int id)
    {
        return await _context.Users.Include(user => user.Tasks).FirstOrDefaultAsync(user => user.UserId == id);
    }

    public async Task<User?> AddAsync(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Username == user.Username)) return null;

        user.Password = _hashingHelper.HashPassword(user.Password);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);

        if (existingUser == null) throw new ArgumentNullException();

        // _context.Entry(existingUser).CurrentValues.SetValues(user);

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;

        await _context.SaveChangesAsync();

        return existingUser;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(user => user != null && user.UserId == id);

        if (existingUser == null) return false;

        _context.Users.Remove(existingUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Task?> AddTaskAsync(int userId, Task task)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

        if (existingUser == null) throw new ArgumentNullException(nameof(userId), "da");

        // existingUser.Tasks.Add(task);
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return task;
    }
}