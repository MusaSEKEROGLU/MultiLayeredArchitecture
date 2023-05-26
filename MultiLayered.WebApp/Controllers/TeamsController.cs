using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Services;
using MultiLayered.Service.Services;
using MultiLayered.WebApp.Exceptions;
using MultiLayered.WebApp.Services;

namespace MultiLayered.WebApp.Controllers
{
    public class TeamsController : Controller
    {        
        // API ile haberleşen MVC için
        private readonly TeamApiService teamApiService;
        private readonly CountryApiService countryApiService;
        public TeamsController(TeamApiService teamApiService, CountryApiService countryApiService)
        {
            this.teamApiService = teamApiService;
            this.countryApiService = countryApiService;
        }

        public async Task<IActionResult> GetTeams()
        {
            return View(await teamApiService.GetTeamsWithCountryAsync());
        }

        public async Task<IActionResult> SaveTeams()
        {
            var countryDto = await countryApiService.GetAllAsync();            
            ViewBag.country = new SelectList(countryDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveTeams(TeamDto teamDto)
        {
            if (ModelState.IsValid)
            { 
                await teamApiService.SaveAsync(teamDto);
                return RedirectToAction(nameof(GetTeams));
            }
            var countryDto = await countryApiService.GetAllAsync();          
            ViewBag.country = new SelectList(countryDto, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Team>))] //hata sayfasına yönlenmesi için
        public async Task<IActionResult> UpdateTeams(int id)
        {
            var team = await teamApiService.GetByIdAsync(id);

            var countryDto = await countryApiService.GetAllAsync();
           
            ViewBag.country = new SelectList(countryDto, "Id", "Name",team.CountryId);

            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeams(TeamDto teamDto)
        {
            if (ModelState.IsValid)
            {
                await teamApiService.UpdateAsync(teamDto);
                return RedirectToAction(nameof(GetTeams));
            }
            var countryDto = await countryApiService.GetAllAsync();        
            ViewBag.country = new SelectList(countryDto, "Id", "Name", teamDto.CountryId);
            return View(teamDto);
        }

        public async Task<IActionResult> DeleteTeams(int id)
        {            
            await teamApiService.DeleteAsync(id);
            return RedirectToAction(nameof(GetTeams));
        }




        // Service ile haberleşen MVC için

        //private readonly ITeamService _teamService;
        //private readonly ICountryService _countryService;
        //private readonly IMapper _mapper;
        //public TeamsController(ITeamService productService, ICountryService countryService, IMapper mapper)
        //{
        //    _productService = productService;
        //    _countryService = countryService;
        //    _mapper = mapper;
        //}


        // Service ile haberleşen MVC için

        //public async Task<IActionResult> GetTeams()
        //{
        //    return View((await _teamService.GetTeamsWithCountryAsync()).Data);
        //}

        //public async Task<IActionResult> SaveTeams()
        //{
        //    var countries = await _countryService.GetAllAsync();
        //    var countryDto = _mapper.Map<List<CountryDto>>(countries.ToList());
        //    ViewBag.country = new SelectList(countryDto, "Id", "Name");
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> SaveTeams(TeamDto teamDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _teamService.AddAsync(_mapper.Map<Team>(teamDto));
        //        return RedirectToAction(nameof(GetTeams));
        //    }
        //    var countries = await _countryService.GetAllAsync();
        //    var countryDto = _mapper.Map<List<CountryDto>>(countries.ToList());
        //    ViewBag.country = new SelectList(countryDto, "Id", "Name");
        //    return View();
        //}

        //[ServiceFilter(typeof(NotFoundFilter<Team>))] //hata sayfasına yönlenmesi için
        //public async Task<IActionResult> UpdateTeams(int id)
        //{
        //    var team = await _teamService.GetByIdAsync(id);
        //    var countries = await _countryService.GetAllAsync();
        //    var countryDto = _mapper.Map<List<CountryDto>>(countries.ToList());
        //    ViewBag.country = new SelectList(countryDto, "Id", "Name", team.CountryId);
        //    return View(_mapper.Map<TeamDto>(team));
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateTeams(TeamDto teamDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _teamService.UpdateAsync(_mapper.Map<Team>(teamDto));
        //        return RedirectToAction(nameof(GetTeams));
        //    }
        //    var countries = await _countryService.GetAllAsync();
        //    var countryDto = _mapper.Map<List<CountryDto>>(countries.ToList());
        //    ViewBag.country = new SelectList(countryDto, "Id", "Name", teamDto.CountryId);
        //    return View(teamDto);
        //}

        //public async Task<IActionResult> DeleteTeams(int id)
        //{
        //    var team = await _teamService.GetByIdAsync(id);
        //    await _productService.RemoveAsync(team);
        //    return RedirectToAction(nameof(GetTeams));
        //}
    }
}
