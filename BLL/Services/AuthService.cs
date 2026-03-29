using AutoMapper;
using BLL.DTO.Users.Login;
using BLL.DTO.Users.User;
using BLL.Services.Interfaces;
using DAL.Repository;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;

        private IUserRepository _repository => _unitOfWork.UserRepository;

        public async Task<string> LoginAsync(LoginRequestDTO request)
        {
            var user = await _repository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("Incorrect username or password");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Incorrect username or password");
            }

            return GenerateJwtToken(user);
        }

        public async Task<UserResponseDTO> RegisterAsync(RegisterRequestDTO request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = _mapper.Map<User>(request);
            await _repository.CreateAsync(newUser);
            await _unitOfWork.Save();

            return _mapper.Map<UserResponseDTO>(newUser); 
        }

        private string GenerateJwtToken(User userEntity)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userEntity.Id.ToString()),        
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                
                new Claim(JwtRegisteredClaimNames.Email, userEntity.Email),
                new Claim("UserName", userEntity.UserName),
                new Claim("Sector", userEntity.Sector.ToString()),
       
                new Claim(ClaimTypes.Role, userEntity.Rol.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
