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
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            _appDbContext.Departments.Add(department);
            await _appDbContext.SaveChangesAsync();
            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _appDbContext.Departments.ToListAsync();
            return Ok(departments);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _appDbContext.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound(); // Department not found
            }

            _appDbContext.Departments.Remove(department);
            await _appDbContext.SaveChangesAsync();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdatedDepartment updatedDepartment)
        {
            var existingDepartment = await _appDbContext.Departments.FindAsync(id);

            if (existingDepartment == null)
            {
                return NotFound(); // Department not found
            }

            existingDepartment.departmentName = updatedDepartment.departmentName;
            existingDepartment.ManagerId = updatedDepartment.ManagerId;

            _appDbContext.Entry(existingDepartment).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return Ok(existingDepartment);
        }


    }

}
