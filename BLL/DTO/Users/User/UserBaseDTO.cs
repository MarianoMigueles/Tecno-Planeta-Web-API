using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.User
{
    public class UserBaseDTO : IBaseDTO
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only letters, numbers and underscores are allowed")]
        public string? UserName { get; set; }

        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must contain uppercase, lowercase, numbers and special characters")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [EnumDataType(typeof(EUserRol), ErrorMessage = "Invalid role")]
        public EUserRol? Rol { get; set; }

        [EnumDataType(typeof(EUserSector), ErrorMessage = "Invalid sector")]
        public EUserSector? Sector { get; set; }
    }
}
