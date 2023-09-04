using Project.Core.Services.Interfaces;
using Project.Datalayer.Context;
using Project.Datalayer.Entities.User;

namespace Project.Core.Services;

public class PermissionService : IPermissionService
{
    private readonly ProjectContext _context;

    public PermissionService(ProjectContext context)
    {
        _context = context;
    }
    public List<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }

    public void AddRolesToUser(List<int> roleIds, int userId)
    {
        foreach (var roleId in roleIds)
        {
            _context.UserRoles.Add(new UserRole()
            {
              RoleId  = roleId,
              UserId = userId
            });
        }

        _context.SaveChanges();
    }
}