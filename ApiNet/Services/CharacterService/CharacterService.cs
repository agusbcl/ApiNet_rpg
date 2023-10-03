﻿namespace ApiNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var dbCharacter = _mapper.Map<Character>(newCharacter);
                _dataContext.Characters.Add(dbCharacter);

                await _dataContext.SaveChangesAsync();

                var dbCharacters = await _dataContext.Characters.ToListAsync();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var dbCharacters = await _dataContext.Characters.ToListAsync();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var dbCharacter = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                var dbCharacter = await _dataContext.Characters.AsTracking().FirstOrDefaultAsync(c => c.Id == id);
                if (dbCharacter == null)
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }

                _mapper.Map(updatedCharacter, dbCharacter);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var dbCharacter = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
                if (dbCharacter == null)
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }

                _dataContext.Characters.Remove(dbCharacter);

                await _dataContext.SaveChangesAsync();

                var dbCharacters = await _dataContext.Characters.ToListAsync();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
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
