using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.User
{
    public class UserBaseDTO
    {
        public string UserName { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }
        public EUserRol Rol { get; set; }
        public EUserSector Sector { get; set; }
    }
}
