using ApiNet.Dtos.Power;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerService _powerService;

        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
        }

        [HttpPost("AddPower")]
        public async Task<ActionResult<ServiceResponse<List<PowerDto>>>> AddPower(PowerDto newPower)
        {
            return Ok(await _powerService.AddPower(newPower));
        }

        [HttpGet("GetAllPowers")]

        public async Task<ActionResult<ServiceResponse<List<PowerDto>>>> Get()
        {
            return Ok(await _powerService.GetAllPowers());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<PowerDto>>> GetPowerById(int id)
        {
            return Ok(await _powerService.GetPowerById(id));

        }

        [HttpPut("UpdatePower/{id}")]
        public async Task<ActionResult<ServiceResponse<PowerDto>>> UpdatePower(int id, PowerDto updatedPower)
        {
            if (id != updatedPower.Id)
            {
                return BadRequest();
            }
            var response = await _powerService.UpdatePower(id, updatedPower);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeletePower/{id}")]
        public async Task<ActionResult<ServiceResponse<PowerDto>>> DeletePower(int id)
        {
            var response = await _powerService.DeletePower(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
