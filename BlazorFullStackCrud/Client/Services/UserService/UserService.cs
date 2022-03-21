using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace BlazorFullStackCrud.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UserService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public List<Role> Roles { get; set; } = new List<Role>();

        public async Task CreateUser(UserDto userDto)
        {
            var result = await _http.PostAsJsonAsync("api/user", userDto);
            await SetUsers(result);
        }

        private async Task SetUsers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<UserDto>>();
            Users = response;
            _navigationManager.NavigateTo("users");
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.DeleteAsync($"api/user/{id}");
            await SetUsers(result);
        }

        public async Task GetRoles()
        {
            var result = await _http.GetFromJsonAsync<List<Role>>("api/user/roles");
            if (result != null)
                Roles = result;
        }

        public async Task<UserDto> GetSingleUser(int id)
        {
            var result = await _http.GetFromJsonAsync<UserDto>($"api/user/{id}");
            if (result != null)
                return result;
            throw new Exception("User not found!");
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<UserDto>>("api/user");
            if (result != null)
                Users = result;
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var result = await _http.PutAsJsonAsync($"api/user/{userDto.Id}", userDto);
            await SetUsers(result);
        }
    }
}
