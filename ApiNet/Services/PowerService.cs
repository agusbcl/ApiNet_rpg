using ApiNet.Dtos.Power;
using AutoMapper.QueryableExtensions;

namespace ApiNet.Services
{
    public class PowerService : IPowerService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;
        public PowerService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<PowerDto>>> AddPower(PowerDto newPower)
        {
            var serviceResponse = new ServiceResponse<List<PowerDto>>();

            try
            {
                var dbPower = _mapper.Map<Power>(newPower);
                _dataContext.Powers.Add(dbPower);

                await _dataContext.SaveChangesAsync();

                var dbPowers = await _dataContext.Powers.ToListAsync();
                serviceResponse.Data = dbPowers.Select(c => _mapper.Map<PowerDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<PowerDto>>> GetAllPowers()
        {
            var serviceResponse = new ServiceResponse<List<PowerDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Powers
                    .ProjectTo<PowerDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PowerDto>> GetPowerById(int id)
        {
            var serviceResponse = new ServiceResponse<PowerDto>();
            try
            {
                serviceResponse.Data = await _dataContext.Powers
                    .ProjectTo<PowerDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PowerDto>> UpdatePower(int id, PowerDto updatedPower)
        {
            var serviceResponse = new ServiceResponse<PowerDto>();

            try
            {
                var dbPower = await _dataContext.Powers.AsTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (dbPower == null)
                {
                    throw new Exception($"Power with Id '{id}' not found.");
                }

                _mapper.Map(updatedPower, dbPower);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<PowerDto>(dbPower);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PowerDto>>> DeletePower(int id)
        {
            var serviceResponse = new ServiceResponse<List<PowerDto>>();

            try
            {
                var dbPower = await _dataContext.Powers.FirstOrDefaultAsync(c => c.Id == id);
                if (dbPower == null)
                {
                    throw new Exception($"Power with Id '{id}' not found.");
                }

                _dataContext.Powers.Remove(dbPower);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.Powers
                    .ProjectTo<PowerDto>(_mapper.ConfigurationProvider)
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
