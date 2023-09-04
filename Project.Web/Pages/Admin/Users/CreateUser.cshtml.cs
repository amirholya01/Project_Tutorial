using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Core.DTOs;
using Project.Core.Services.Interfaces;

namespace Project.Web.Pages.Admin.Users;

public class CreateUser : PageModel
{
    private readonly IUserService _userService;
    private readonly IPermissionService _permissionService;

    public CreateUser(IUserService userService, IPermissionService permissionService)
    {
        _userService = userService;
        _permissionService = permissionService;
    }
    
    
    [BindProperty]
    public CreateUserViewModel CreateUserViewModel { get; set; }
    public void OnGet()
    {
        ViewData["Roles"] = _permissionService.GetRoles();
    }

    public IActionResult OnPost(List<int> SelectedRoles)
    {
        if (!ModelState.IsValid)
            return Page();
        int userId = _userService.AddUserFromAdmin(CreateUserViewModel);
        _permissionService.AddRolesToUser(SelectedRoles, userId);

        return Redirect("/Admin/Users");
    }
}