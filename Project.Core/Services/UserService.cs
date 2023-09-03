using Project.Core.Services.Interfaces;
using Project.Datalayer.Context;
using Project.Datalayer.Entities.User;

namespace Project.Core.Services;

public class UserService : IUserService
{
    private readonly ProjectContext _context;

    public UserService(ProjectContext context)
    {
        _context = context;
    }
    
    
    public bool IsUsernameExist(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }

    public bool IsEmailExist(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public int AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.UserId;
    }
}