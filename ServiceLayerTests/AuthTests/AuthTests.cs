using BLL.DTO.Users.Login;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.AuthTests
{
    public class AuthTests : AuthTestBase
    {
        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenRequestEmailIsNull()
        {
            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(null!))
                .ReturnsAsync((Entities.Users.User)null!);

            var act = async () => await Service.LoginAsync(new LoginRequestDTO { Email = null!, Password = "Pass@1234" });

            await act.Should().ThrowAsync<Exception>();
        }

        [Fact]
        public async Task LoginAsync_ShouldCallUserRepository_WithProvidedEmail()
        {
            var email = "check@tecno.com";
            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(email))
                .ReturnsAsync((Entities.Users.User)null!);

            try { await Service.LoginAsync(new LoginRequestDTO { Email = email, Password = "Pass@1" }); }
            catch { /* esperado */ }

            UserRepositoryMock.Verify(r => r.GetByEmailAsync(email), Times.Once);
        }
    }
}
