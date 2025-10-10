using BLL.DTO.Service;
using BLL.DTO.User;
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
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("name")]
        public async Task<ActionResult<UserDTO>> GetUserByName([FromQuery] string name)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("sector")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllBySector([FromQuery] List<EUserSector>? sectors)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("rol")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllByRol([FromQuery] List<EUserRol>? rols)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/name")]
        public Task<ActionResult<UserDTO>> UpdateName(int id, [FromBody] string newName)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/password")]
        public Task<ActionResult<UserDTO>> UpdatePassword(int id, [FromBody] string newPassword)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/rol")]
        public Task<ActionResult<UserDTO>> UpdateRol(int id, [FromBody] EUserRol newRol)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/sector")]
        public Task<ActionResult<UserDTO>> UpdateSector(int id, [FromBody] EUserSector newSector)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public Task<ActionResult<UserDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public Task<ActionResult<UserDTO>> Create([FromBody] UserDTO newUser)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
