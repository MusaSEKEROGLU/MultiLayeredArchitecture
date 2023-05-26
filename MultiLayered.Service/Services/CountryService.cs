using AutoMapper;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Repositories;
using MultiLayered.Core.Services;
using MultiLayered.Core.UnitOfWorks;

namespace MultiLayered.Service.Services
{
    public class CountryService : GenericService<Country>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(IGenericRepository<Country> repository, IUnitOfWork unitOfWork,
            ICountryRepository countryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CountryWithTeamsDto>> GetSingleCountryByIdWithTeamsAsync(int countryId)
        {
            var country = await _countryRepository.GetSingleCountryByIdWithTeamsAsync(countryId);
            var countryDto = _mapper.Map<CountryWithTeamsDto>(country);
            return CustomResponseDto<CountryWithTeamsDto>.Success(200, countryDto);
        }
    }
}
