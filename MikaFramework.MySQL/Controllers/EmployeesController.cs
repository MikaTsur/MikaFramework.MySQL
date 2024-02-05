﻿using Microsoft.AspNetCore.Mvc;
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
        

    }


}
