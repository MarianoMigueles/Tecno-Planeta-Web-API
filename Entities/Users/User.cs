using Entities.Users.Enums;

namespace Entities.Users
{
    public class User : AbstractEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EUserRol Rol { get; set; }
        public EUserSector Sector { get; set; }

        public void ChangeUserRol(EUserRol newRol)
        {
            // The rol can't be the same rol
            if (newRol == Rol)
                throw new NotImplementedException("not implement the specific exeption yet");

            this.Rol = newRol;           
        }

        public void ChangeUserSector(EUserSector newSector) {
            // The sector can't be the same sector
            if (newSector == Sector)
                throw new NotImplementedException("not implement the specific exeption yet");

            this.Sector = newSector;
        }
    }
}
