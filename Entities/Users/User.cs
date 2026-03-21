using BCrypt.Net;
using Entities.Users.Enums;
using Exeptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.Users
{
    public class User : AbstractEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public EUserRol Rol { get; private set; }
        public EUserSector Sector { get; private set; }

        /// <summary>
        /// Asigna el password ya hasheado (el hash lo genera AuthService con BCrypt antes de llamar este método).
        /// </summary>
        public void SetPassword(string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword))
                throw new ValidationException("Password hash cannot be empty.");

            Password = hashedPassword;
        }

        /// <summary>
        /// Verifica un password en texto plano contra el hash almacenado usando BCrypt.
        /// </summary>
        public bool VerifyPassword(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return false;

            return BCrypt.Net.BCrypt.Verify(plainPassword, Password);
        }

        public void EditRol(EUserRol newRol)
        {
            if (newRol == Rol)
                throw new ValidationException("Rol is the same to the value already set.");

            this.Rol = newRol;
        }

        public void EditSector(EUserSector newSector)
        {
            if (newSector == Sector)
                throw new ValidationException("Sector is the same to the value already set.");

            this.Sector = newSector;
        }

        public void EditPassword(string newPassword)
        {
            if (newPassword == Password)
                throw new ValidationException("Password is the same to the value already set.");

            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ValidationException("Password cannot be empty");

            if (newPassword.Length < 8)
                throw new ValidationException("Password must be at least 8 characters long");

            if (newPassword.Length > 128)
                throw new ValidationException("Password is too long");

            if (!Regex.IsMatch(newPassword, @"[0-9]"))
                throw new ValidationException("Password must contain at least one number");

            if (!Regex.IsMatch(newPassword, @"[a-z]"))
                throw new ValidationException("Password must contain at least one lowercase letter");

            if (!Regex.IsMatch(newPassword, @"[A-Z]"))
                throw new ValidationException("Password must contain at least one uppercase letter");

            if (!Regex.IsMatch(newPassword, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
                throw new ValidationException("Password must contain at least one special character");

            this.Password = newPassword;
        }
    }
}
