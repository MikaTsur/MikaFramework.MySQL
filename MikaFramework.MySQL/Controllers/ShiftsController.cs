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
    public class ShiftsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ShiftsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddShift(Shift shift)
        {
            _appDbContext.Shifts.Add(shift);
            await _appDbContext.SaveChangesAsync();
            return Ok(shift);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shifts = await _appDbContext.Shifts.ToListAsync();
            return Ok(shifts);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shift = await _appDbContext.Shifts.FindAsync(id);

            if (shift == null)
            {
                return NotFound(); // return 404 Not Found if the department with the specified ID is not found
            }

            return Ok(shift);
        }



    }

}
