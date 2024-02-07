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
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public EmployeesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _appDbContext.Employees.ToListAsync();
            return Ok(employees);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(); // return 404 Not Found if the department with the specified ID is not found
            }

            return Ok(employee);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id); // Corrected the DbSet reference

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();

            return Ok(employee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedEmployee(int id, UpdatedEmployee updatedEmployee)
        {
            var existingEmployee = await _appDbContext.Employees.FindAsync(id);

            if (existingEmployee == null)
            {
                return NotFound(); // Department not found
            }

            existingEmployee.firstname = updatedEmployee.firstname;
            existingEmployee.lastname = updatedEmployee.lastname;
            existingEmployee.startWorkYear = updatedEmployee.startWorkYear;
            existingEmployee.DepartmentID = updatedEmployee.DepartmentID;


            _appDbContext.Entry(existingEmployee).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return Ok(existingEmployee);
        }


    }


}
