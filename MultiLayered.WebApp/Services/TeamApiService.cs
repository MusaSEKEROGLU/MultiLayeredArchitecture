using MultiLayered.Core.Dtos;

namespace MultiLayered.WebApp.Services
{
    public class TeamApiService
    {
        private readonly HttpClient _httpClient;
        public TeamApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TeamWithCountryDto>> GetTeamsWithCountryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<TeamWithCountryDto>>>
                ("Teams/GetTeamsWithCountryAsync");

            return response.Data;
        }

        public async Task<TeamDto> SaveAsync(TeamDto newTeam)
        {
            var response = await _httpClient.PostAsJsonAsync("Teams", newTeam);

            if (!response.IsSuccessStatusCode) return null; //başarısız ise

            //başarılı ise
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<TeamDto>>();

            return responseBody.Data;
        }

        public async Task<TeamDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<TeamDto>>($"Teams/{id}");

            return response.Data;
        }

        public async Task<bool> UpdateAsync(TeamDto updateTeam)
        {
            var response = await _httpClient.PutAsJsonAsync("Teams", updateTeam); 
            
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Teams/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
