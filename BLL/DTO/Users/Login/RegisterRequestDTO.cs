using Entities.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Users.Login
{
    /// <summary>DTO exclusivo para el endpoint POST /auth/register.</summary>
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only letters, numbers and underscores are allowed")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must contain uppercase, lowercase, numbers and special characters")]
        public string Password { get; set; } = string.Empty;

        [EnumDataType(typeof(EUserRol), ErrorMessage = "Invalid role")]
        public EUserRol Rol { get; set; } = EUserRol.EMPLOYEE;

        [EnumDataType(typeof(EUserSector), ErrorMessage = "Invalid sector")]
        public EUserSector Sector { get; set; } = EUserSector.SALES;
    }
}
