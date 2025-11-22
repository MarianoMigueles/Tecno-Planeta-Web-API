using BLL.DTO.Users.User;
using BLL.Services.Interfaces;
using Entities.Users.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class UserController(IUserService service, IConfiguration configuration) : AbstractBaseController<IUserService>(service)
    {
        private readonly IConfiguration _configuration = configuration;

        //--------------------------------- GET ------------------------------------------------------
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserById(int id)
        {
            var user = await service.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("name")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByName([FromQuery] string name)
        {
            var user = await service.GetByNameAsync(name);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("all/sector")]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAllBySector([FromQuery] EUserSector sectors)
        {
            var users = await service.GetAllBySectorAsync(sectors);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("all/rol")]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAllByRol([FromQuery] EUserRol rols)
        {
            var users = await service.GetAllByRolAsync(rols);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAll()
        {
            var users = await service.GetAllAsync();
            return Ok(users);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}/name")]
        public async Task<ActionResult<UserResponseDTO>> UpdateName(int id, [FromBody] string newName)
        {
            var user = await service.UpdateNameAsync(id, newName);
            return Ok(user);
        }
        [HttpPatch("{id:int}/password")]
        public async Task<ActionResult<UserResponseDTO>> UpdatePassword(int id, [FromBody] string newPassword)
        {
            var user = await service.UpdatePasswordAsync(id, newPassword);
            return Ok(user);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/rol")]
        public async Task<ActionResult<UserResponseDTO>> UpdateRol(int id, [FromBody] EUserRol newRol)
        {
            var user = await service.UpdateRolAsync(id, newRol);
            return Ok(user);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/sector")]
        public async Task<ActionResult<UserResponseDTO>> UpdateSector(int id, [FromBody] EUserSector newSector)
        {
            var user = await service.UpdateSectorAsync(id, newSector);
            return Ok(user);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserResponseDTO>> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Create([FromBody] UserCreateDTO newUser)
        {
            var user = await service.CreateAsync(newUser);
            return Ok(user);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
