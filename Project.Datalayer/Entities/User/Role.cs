using System.ComponentModel.DataAnnotations;

namespace Project.Datalayer.Entities.User;

public class Role
{
    public Role()
    {
        
    }
    
        
    [Key]
    public int RoleId { get; set; }
    
    [Display(Name = "title of role")]
    [Required(ErrorMessage = "The {0} must not be empty.")]
    [MaxLength(10, ErrorMessage = "The {0} can not be more than {1} characters.")]
    public string RoleTitle { get; set; }


    #region Relations

    public virtual ICollection<UserRole> UserRole { get; set; }
    
    #endregion
}