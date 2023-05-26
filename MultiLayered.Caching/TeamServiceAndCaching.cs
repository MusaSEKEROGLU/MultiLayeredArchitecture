using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;
using MultiLayered.Core.Repositories;
using MultiLayered.Core.Services;
using MultiLayered.Core.UnitOfWorks;
using MultiLayered.Service.Exceptions;
using System.Linq.Expressions;

namespace MultiLayered.Caching
{
    public class TeamServiceAndCaching : ITeamService
    {
        private const string CachingTeamKey = "teamCaching";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ITeamRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TeamServiceAndCaching(IMapper mapper, IMemoryCache memoryCache, ITeamRepository repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CachingTeamKey, out _))
            {
                _memoryCache.Set(CachingTeamKey, _repository.GetTeamsWithCountryAsync().Result);
                //constructor içinde await kullanamadığımız için /Result ile Asenkronu senkrona dönüştürdük.
            }
        }

        public async Task<Team> AddAsync(Team entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAscync();
            await CachingAllTeamsAsync(); //caching Method
            return entity;
        }

        public async Task<IEnumerable<Team>> AddRangeAsync(IEnumerable<Team> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAscync();
            await CachingAllTeamsAsync(); //caching Method
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Team, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Team>>(CachingTeamKey));
        }

        public Task<Team> GetByIdAsync(int id)
        {
            var team = _memoryCache.Get<List<Team>>(CachingTeamKey).FirstOrDefault(x => x.Id == id);
            if (team == null)
            {
                throw new NotFoundException($"{typeof(Team).Name}({id}) not found.");
            }
            return Task.FromResult(team);
        }


        //Servisleri kullanan MVC uygulaması için
        //public Task<List<TeamWithCountryDto>> GetTeamsWithCountryAsync()
        //{
        //    var teams = _memoryCache.Get<IEnumerable<Team>>(CachingTeamKey);
        //    var teamsWithCountry = _mapper.Map<List<TeamWithCountryDto>>(teams);
        //    return Task.FromResult(teamsWithCountry);
        //}


        //API yi kullanan MVC uygulaması için
        public Task<CustomResponseDto<List<TeamWithCountryDto>>> GetTeamsWithCountryAsync()
        {
            var teams = _memoryCache.Get<IEnumerable<Team>>(CachingTeamKey);
            var teamsWithCountry = _mapper.Map<List<TeamWithCountryDto>>(teams);
            return Task.FromResult(CustomResponseDto<List<TeamWithCountryDto>>.Success(200,teamsWithCountry));
        }

        public async Task RemoveAsync(Team entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAscync();
            await CachingAllTeamsAsync(); //caching Method            
        }

        public async Task RemoveRangeAsync(IEnumerable<Team> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAscync();
            await CachingAllTeamsAsync(); //caching Method 
        }

        public async Task UpdateAsync(Team entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAscync();
            await CachingAllTeamsAsync(); //caching Method 
        }

        public IQueryable<Team> Where(Expression<Func<Team, bool>> expression)
        {
            return _memoryCache.Get<List<Team>>(CachingTeamKey).Where(expression.Compile()).AsQueryable();
        }



        //Kendimiz oluşturduk teamservisden gelmedi caching için
        public async Task CachingAllTeamsAsync()
        {
            await _memoryCache.Set(CachingTeamKey, _repository.GetAll().ToListAsync());
        }
    }
}
