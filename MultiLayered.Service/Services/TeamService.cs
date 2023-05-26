using AutoMapper;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Repositories;
using MultiLayered.Core.Services;
using MultiLayered.Core.UnitOfWorks;


namespace MultiLayered.Service.Services
{
    public class TeamService : GenericService<Team>, ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TeamService(IGenericRepository<Team> repository, IUnitOfWork unitOfWork,
            ITeamRepository teamRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        //API yi kullanan MVC uygulaması için
        public async Task<CustomResponseDto<List<TeamWithCountryDto>>> GetTeamsWithCountryAsync()
        {
            var teams = await _teamRepository.GetTeamsWithCountryAsync();
            var teamsDto = _mapper.Map<List<TeamWithCountryDto>>(teams);
            return CustomResponseDto<List<TeamWithCountryDto>>.Success(200,teamsDto);
        }


        //Servisleri kullanan MVC uygulaması için

        //public async Task<List<TeamWithCountryDto>> GetTeamsWithCountryAsync()
        //{
        //    var teams = await _teamRepository.GetTeamsWithCountryAsync();
        //    var teamsDto = _mapper.Map<List<TeamWithCountryDto>>(teams);
        //    return  teamsDto;
        //}
    }
}
