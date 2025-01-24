using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Identity;

namespace Final.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
    }

    public void Register(User user, string password)
    {
        user.PasswordHash = _passwordHasher.HashPassword(user, password);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? Authenticate(string email, string password)
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == email);
        if (user == null) return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success ? user : null;
    }
    
    public User? GetUserById(int id)
    {
        return _context.Users.SingleOrDefault(u => u.Id == id);
    }
}