using System.ComponentModel.DataAnnotations;

namespace Project.Datalayer.Entities.User;

public class UserRole
{
    public UserRole()
    {
        
    }
    
    
        
    [Key]
    public int UR_Id { get; set; }
    //FK---> Which User
    public int UserId { get; set; }
    //FK---> Which Role
    public int RoleId { get; set; }


    #region Relations

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }

    #endregion
}