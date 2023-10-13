using ApiNet.Dtos.RpgClass;
using AutoMapper.QueryableExtensions;

namespace ApiNet.Services
{
    public class RpgClassService : IRpgClassService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;
        public RpgClassService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RpgClassDto>>> AddRpgClass(RpgClassDto newRpgClass)
        {
            var serviceResponse = new ServiceResponse<List<RpgClassDto>>();

            try
            {
                var dbClass = _mapper.Map<RpgClass>(newRpgClass);
                _dataContext.RpgClasses.Add(dbClass);

                await _dataContext.SaveChangesAsync();

                var dbClasses = await _dataContext.RpgClasses.ToListAsync();
                serviceResponse.Data = dbClasses.Select(c => _mapper.Map<RpgClassDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<RpgClassDto>>> GetAllClasses()
        {
            var serviceResponse = new ServiceResponse<List<RpgClassDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.RpgClasses
                    .ProjectTo<RpgClassDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<RpgClassDto>> GetRpgClassById(int id)
        {
            var serviceResponse = new ServiceResponse<RpgClassDto>();
            try
            {
                serviceResponse.Data = await _dataContext.RpgClasses
                    .ProjectTo<RpgClassDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<RpgClassDto>> UpdateRpgClass(int id, RpgClassDto updatedClass)
        {
            var serviceResponse = new ServiceResponse<RpgClassDto>();

            try
            {
                var dbClass = await _dataContext.RpgClasses.AsTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (dbClass == null)
                {
                    throw new Exception($"Rpg Class with Id '{id}' not found.");
                }

                _mapper.Map(updatedClass, dbClass);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<RpgClassDto>(dbClass);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<RpgClassDto>>> DeleteRpgClass(int id)
        {
            var serviceResponse = new ServiceResponse<List<RpgClassDto>>();

            try
            {
                var dbClass = await _dataContext.RpgClasses.FirstOrDefaultAsync(c => c.Id == id);
                if (dbClass == null)
                {
                    throw new Exception($"Rpg Class with Id '{id}' not found.");
                }

                _dataContext.RpgClasses.Remove(dbClass);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.RpgClasses
                    .ProjectTo<RpgClassDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
