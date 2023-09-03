using System.ComponentModel.DataAnnotations;

namespace Project.Core.DTOs;

public class RegisterViewModel
{
    [Display(Name = "username")]
    [Required(ErrorMessage = "The {0} must not be empty.")]
    [MaxLength(15, ErrorMessage = "The {0} can not be more than {1} characters.")]
    public string Username { get; set; }
    
    [Display(Name = "email")]
    [Required(ErrorMessage = "The {0} must not be empty.")]
    [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
    [EmailAddress(ErrorMessage = "The {0} is not valid.")]
    public string Email { get; set; }
    
    [Display(Name = "password")]
    [Required(ErrorMessage = "The {0} must not be empty.")]
    [MaxLength(256, ErrorMessage = "The {0} can not be more than {1} characters.")]
    public string Password { get; set; }
    
    [Display(Name = "confirm password")]
    [Required(ErrorMessage = "The {0} must not be empty.")]
    [MaxLength(256, ErrorMessage = "The {0} can not be more than {1} characters.")]
    [Compare("Password", ErrorMessage = "The password and confirmed password have a problem.")]
    public string ConfirmPassword { get; set; }
}