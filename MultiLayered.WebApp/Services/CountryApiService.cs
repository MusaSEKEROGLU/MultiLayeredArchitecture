using MultiLayered.Core.Dtos;

namespace MultiLayered.WebApp.Services
{
    public class CountryApiService
    {

        private readonly HttpClient _httpClient;
        public CountryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CountryDto>>>
               ("Countries");

            return response.Data;
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CountryDto>>($"Countries/{id}");

            return response.Data;
        }
    }
}
