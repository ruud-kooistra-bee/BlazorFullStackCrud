using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetSingleUser(int id)
        {
            UserDto userDto = new UserDto();

            var user = await _context.Users
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("This user does not exist!");
            }

            userDto.Id = user.Id;
            userDto.Username = user.Username;
            userDto.Email = user.Email;
            userDto.RoleId = user.RoleId;
            userDto.DateOfBirth = user.DateOfBirth;

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(UserDto userDto)
        {
            User user = new User();

            user.Email = userDto.Email;
            user.Username = userDto.Username;
           
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            user.RoleId = userDto.RoleId;
            user.DateOfBirth = userDto.DateOfBirth;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(UserDto userDto, int id)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbUser == null)
                return NotFound("This user does not exist!");

            dbUser.Email = userDto.Email;

            dbUser.Username = userDto.Username;

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            dbUser.PasswordHash = passwordHash;
            dbUser.PasswordSalt = passwordSalt;

            dbUser.RoleId = userDto.RoleId;

            dbUser.DateOfBirth = userDto.DateOfBirth;

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbUser == null)
                return NotFound("This user does not exist!");

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        private async Task<List<User>> GetDbUsers()
        {
            return await _context.Users.ToListAsync();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
