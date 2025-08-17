namespace Entities.Users
{
    public class User : AbstractEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Rol {  get; set; }
        public required string Sector { get; set; }

    }
}
