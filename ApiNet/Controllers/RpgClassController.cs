using ApiNet.Dtos.RpgClass;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgClassController : ControllerBase
    {
        private readonly IRpgClassService _rpgClassService;

        public RpgClassController(IRpgClassService rpgClassService)
        {
            _rpgClassService = rpgClassService;
        }

        [HttpPost("AddRpgClass")]
        public async Task<ActionResult<ServiceResponse<List<RpgClassDto>>>> AddRpgClass(RpgClassDto newClass)
        {
            return Ok(await _rpgClassService.AddRpgClass(newClass));
        }

        [HttpGet("GetAllClasses")]

        public async Task<ActionResult<ServiceResponse<List<RpgClassDto>>>> Get()
        {
            return Ok(await _rpgClassService.GetAllClasses());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<RpgClassDto>>> GetRpgClassById(int id)
        {
            return Ok(await _rpgClassService.GetRpgClassById(id));

        }

        [HttpPut("UpdateRpgClass/{id}")]
        public async Task<ActionResult<ServiceResponse<RpgClassDto>>> UpdateRpgClass(int id, RpgClassDto updatedClass)
        {
            if (id != updatedClass.Id)
            {
                return BadRequest();
            }
            var response = await _rpgClassService.UpdateRpgClass(id, updatedClass);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteRpgClass/{id}")]
        public async Task<ActionResult<ServiceResponse<RpgClassDto>>> DeleteRpgClass(int id)
        {
            var response = await _rpgClassService.DeleteRpgClass(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }

}

