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
    public class CountriesController : CustomBaseController
    {   
        private readonly ICountryService _countryervice;
        private readonly IMapper _mapper;
        public CountriesController(ICountryService countryervice, IMapper mapper)
        {
            _countryervice = countryervice;
            _mapper = mapper;
        }

        //b metodu sonradan ekledim

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryervice.GetAllAsync();

            var countriesDto = _mapper.Map<List<CountryDto>>(countries.ToList());

            return CreateActionResult(CustomResponseDto<List<CountryDto>>.Success(200,countriesDto));   
        }

        [ServiceFilter(typeof(NotFountFilter<Country>))]
        [HttpGet("[action]/{countryId}")]
        public async Task<IActionResult> GetSingleCountryByIdWithTeams(int countryId)
        {
            return CreateActionResult(await _countryervice.GetSingleCountryByIdWithTeamsAsync(countryId));
        }
    }
}
