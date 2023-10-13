using ApiNet.Dtos.RpgClass;

namespace ApiNet.Services.Interfaces
{
    public interface IRpgClassService
    {
        Task<ServiceResponse<List<RpgClassDto>>> AddRpgClass(RpgClassDto newRpgClass);
        Task<ServiceResponse<List<RpgClassDto>>> GetAllClasses();
        Task<ServiceResponse<RpgClassDto>> GetRpgClassById(int id);
        Task<ServiceResponse<RpgClassDto>> UpdateRpgClass(int id, RpgClassDto updatedClass);
        Task<ServiceResponse<List<RpgClassDto>>> DeleteRpgClass(int id);

    }
}
