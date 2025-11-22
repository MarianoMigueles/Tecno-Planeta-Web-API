using BLL.DTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractBaseController<T>(T service) : Controller where T : IService
    {
        protected readonly T service = service;
    }
}
