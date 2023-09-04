using Project.Datalayer.Entities.User;

namespace Project.Core.DTOs;


public class UserForAdminViewModel
{
    public List<User> Users { get; set; }
    public int CurrentPage  { get; set; }
    public int PageCount  { get; set; }
}