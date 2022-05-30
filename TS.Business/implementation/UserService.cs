using Microsoft.EntityFrameworkCore;
using TS.Business.Interfaces;
using TS.Model.Entities;
using TS.Model.Mappers;
using TS.Model.ViewModels;
using TS.Repository;

namespace TS.Business.implementation;

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
        return await _context.Users.FirstOrDefaultAsync(user => user != null && user.Id == id);
    }

    public async Task<User?> AddAsync(User user)
    {
        if (await _context.Users.AnyAsync(u => u != null && u.Username == user.Username)) return null;

        user.Password = _hashingHelper.HashPassword(user.Password);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

        if (existingUser == null) throw new ArgumentNullException();

        // _context.Entry(existingUser).CurrentValues.SetValues(user);

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        
        await _context.SaveChangesAsync();

        return existingUser;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(user => user != null && user.Id == id);

        if (existingUser == null) return false;

        _context.Users.Remove(existingUser);
        await _context.SaveChangesAsync();
        return true;
    }
}