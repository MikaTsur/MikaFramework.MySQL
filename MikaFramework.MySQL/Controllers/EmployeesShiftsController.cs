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

    public class EmployeesShiftsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeesShiftsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeShift(EmployeeShift employeeshift)
        {
            employeeshift.ID = 0;
            _appDbContext.EmployeesShifts.Add(employeeshift);
            await _appDbContext.SaveChangesAsync();
            return Ok(employeeshift);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeesshifts = await _appDbContext.EmployeesShifts.ToListAsync();
            return Ok(employeesshifts);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeshift = await _appDbContext.EmployeesShifts.FindAsync(id);

            if (employeeshift == null)
            {
                return NotFound(); // return 404 Not Found if the department with the specified ID is not found
            }

            return Ok(employeeshift);
        }



    }

}