using Project.Datalayer.Entities.User;

namespace Project.Core.Services.Interfaces;

public interface IUserService
{
    bool IsUsernameExist(string username);
    bool IsEmailExist(string email);
    int AddUser(User user);
}