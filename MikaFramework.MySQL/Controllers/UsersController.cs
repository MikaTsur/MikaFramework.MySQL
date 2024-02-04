using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MikaFramework.MySQL.Data;
using MikaFramework.MySQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;



namespace MikaFramework.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public UsersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return Ok(users);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(); // User not found
            }

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            return Ok(user);
        }
        

    }


}
