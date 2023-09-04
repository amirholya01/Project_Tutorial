using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Core.DTOs;
using Project.Core.Services.Interfaces;

namespace Project.Web.Pages.Admin.Users;

public class Index : PageModel
{
    private readonly IUserService _userService;

    public Index(IUserService userService)
    {
        _userService = userService;
    }

    public UserForAdminViewModel UserForAdminViewModel { get; set; }
    
    public void OnGet()
    {
        UserForAdminViewModel = _userService.GetUsers();
    }
}