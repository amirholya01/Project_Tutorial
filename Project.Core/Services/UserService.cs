using Project.Core.DTOs;
using Project.Core.Generator;
using Project.Core.Security;
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

    public UserForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername = "")
    {
        IQueryable<User> result = _context.Users;
        if (!string.IsNullOrEmpty(filterEmail))
            result = result.Where(u => u.Email.Contains(filterEmail));
        if (!string.IsNullOrEmpty(filterUsername))
            result = result.Where(u => u.Username.Contains(filterUsername));

        int take = 20;
        int skip = (pageId - 1) * take;

        UserForAdminViewModel list = new UserForAdminViewModel();
        list.CurrentPage = pageId;
        list.PageCount = result.Count() / take;
        list.Users = _context.Users.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
        return list;
    }

    public int AddUserFromAdmin(CreateUserViewModel user)
    {
        User addUser = new User();
        addUser.Password = PasswordHelper.EncodePassword(user.Password);
        addUser.ActiveCode = StringGenerator.CodeGenerator();
        addUser.Email = user.Email;
        addUser.IsActive = true;
        addUser.RegisterDate = DateTime.Now;
        addUser.Username = user.Username;
        return AddUser(addUser);
    }
}