using ApiNet.Dtos.Power;
using ApiNet.Dtos.RpgClass;

namespace ApiNet.Services.Interfaces
{
    public interface IPowerService
    {
        Task<ServiceResponse<List<PowerDto>>> AddPower(PowerDto newPower);
        Task<ServiceResponse<List<PowerDto>>> GetAllPowers();
        Task<ServiceResponse<PowerDto>> GetPowerById(int id);
        Task<ServiceResponse<PowerDto>> UpdatePower(int id, PowerDto updatedPower);
        Task<ServiceResponse<List<PowerDto>>> DeletePower(int id);
    }
}
