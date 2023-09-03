using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Generator;
using Project.Core.Security;
using Project.Core.Services.Interfaces;
using Project.Core.Utils;
using Project.Datalayer.Entities.User;

namespace Project.Web.Controllers;

public class Account: Controller
{

    private readonly IUserService _userService;

    public Account(IUserService userService)
    {
        _userService = userService;
    }

    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [Route("Register")]
    [HttpPost]
    public IActionResult Register(RegisterViewModel register)
    {
        if (!ModelState.IsValid)
        {
            return View(register); 
        }
            
        if (_userService.IsUsernameExist(register.Username))
        {
            ModelState.AddModelError("Username", "The username is not valid.");
            return View(register); 
        }

        if (_userService.IsEmailExist(Valid.EmailValid(register.Email)))
        {
            ModelState.AddModelError("Email", "The email is not valid.");
            return View(register);
        }
            
        
        Datalayer.Entities.User.User user = new User()
            {
                ActiveCode = StringGenerator.CodeGenerator(),
                Email = Valid.EmailValid(register.Email),
                IsActive = false,
                Password = PasswordHelper.EncodePassword(register.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "default.jpg",
                Username = register.Username
            }
            ;
        _userService.AddUser(user);
        return View("SuccessRegister");
    }
}