using BlazorFullStackCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var users = await _context.Users.Include(sh => sh.Role).ToListAsync();
            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var user = await _context.Users
                .Include(h => h.Role)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("This user does not exist!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            user.Role = null;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user, int id)
        {
            var dbUser = await _context.Users
                .Include(sh => sh.Role)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbUser == null)
                return NotFound("This user does not exist!");

            dbUser.Email = user.Email;

            dbUser.Username = user.Username;

            dbUser.PasswordHash = user.PasswordHash;
            dbUser.PasswordSalt = user.PasswordSalt;

            dbUser.RoleId = user.RoleId;

            dbUser.DateOfBirth = user.DateOfBirth;

            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var dbUser = await _context.Users
                .Include(sh => sh.Role)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbUser == null)
                return NotFound("This user does not exist!");

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsers());
        }

        private async Task<List<User>> GetDbUsers()
        {
            return await _context.Users.Include(sh => sh.Role).ToListAsync();
        }
    }
}
