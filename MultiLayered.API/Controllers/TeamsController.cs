using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiLayered.API.ValidationFilters;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Services;

namespace MultiLayered.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : CustomBaseController
    {
        //private readonly IGenericService<Team> _service;
        private readonly IMapper _mapper;
        private readonly ITeamService _service;
        public TeamsController(IMapper mapper, ITeamService service)
        {
            _service = service;
            _mapper = mapper;            
        }

        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTeamsWithCountryAsync()
        {            
            return CreateActionResult(await _service.GetTeamsWithCountryAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _service.GetAllAsync();
            var teamDtos = _mapper.Map<List<TeamDto>>(teams.ToList());
            return CreateActionResult(CustomResponseDto<List<TeamDto>>.Success(200, teamDtos));
        }

        [ServiceFilter(typeof(NotFountFilter<Team>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _service.GetByIdAsync(id);
            var teamDto = _mapper.Map<TeamDto>(team);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(200, teamDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TeamDto teamDto)
        {
            var team = await _service.AddAsync(_mapper.Map<Team>(teamDto));
            var teamsDto = _mapper.Map<TeamDto>(team);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(201, teamsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TeamUpdateDto teamUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Team>(teamUpdateDto));            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFountFilter<Team>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(team);            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
 