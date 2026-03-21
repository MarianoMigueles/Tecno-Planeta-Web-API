using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ServiceLayerTests.AuthTests
{
    public class AuthTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IUserRepository> UserRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly IConfiguration Configuration;
        protected readonly AuthService Service;

        protected AuthTestBase()
        {
            UnitOfWorkMock      = new Mock<IUnitOfWork>();
            UserRepositoryMock  = new Mock<IUserRepository>();

            UnitOfWorkMock.Setup(u => u.UserRepository).Returns(UserRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);

            // IConfiguration en memoria con los valores JWT necesarios
            var inMemoryConfig = new Dictionary<string, string?>
            {
                { "Jwt:Key",      "SuperSecretTestKey_MinLength32Chars!!" },
                { "Jwt:Issuer",   "TecnoPlanetaTestIssuer"               },
                { "Jwt:Audience", "TecnoPlanetaTestAudience"             }
            };
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfig)
                .Build();

            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>())
                .CreateMapper();

            Service = new AuthService(UnitOfWorkMock.Object, Mapper, Configuration);
        }

        /// <summary>
        /// Crea un User con password hasheado con BCrypt, listo para usarse en tests de Login.
        /// </summary>
        protected static Entities.Users.User CreateUserWithHashedPassword(string plainPassword)
        {
            var user = SharedMockData.GetSingleUser();
            var hash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            // Seteamos el password usando reflexión porque la propiedad es privada
            typeof(Entities.Users.User)
                .GetProperty("Password")!
                .SetValue(user, hash);
            return user;
        }
    }
}
