using Entities.Users.Enums;

namespace Entities.Users
{
    public class User : AbstractEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EUserRol Rol { get; set; }
        public EUserSector Sector { get; set; }


        public void EditUserName(string newUserName)
        {
            throw new NotImplementedException();
        }

        public void EditUserPassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserRol(string newRol)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserSector(string newSector) {
            throw new NotImplementedException();
        }
    }
}
