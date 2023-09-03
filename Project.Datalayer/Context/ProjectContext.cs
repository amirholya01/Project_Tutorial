using Microsoft.EntityFrameworkCore;
using Project.Datalayer.Entities.User;

namespace Project.Datalayer.Context;

public class ProjectContext:DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options): base(options)
    {
        
    }
    
    
    #region User

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion 
}