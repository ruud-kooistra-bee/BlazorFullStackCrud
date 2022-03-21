namespace BlazorFullStackCrud.Client.Services.UserService
{
    public interface IUserService
    {
        List<UserDto> Users { get; set; }

        List<Role> Roles { get; set; }

        Task GetRoles();

        Task GetUsers();

        Task<UserDto> GetSingleUser(int id);

        Task CreateUser(UserDto userDto);
        
        Task UpdateUser(UserDto userDto);

        Task DeleteUser(int id);
    }
}
